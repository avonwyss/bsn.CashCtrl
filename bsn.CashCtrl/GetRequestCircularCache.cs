using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace bsn.CashCtrl {
	public class GetRequestCircularCache: ICashCtrlClientCache {
		private class CachedGetRequest {
			public CachedGetRequest(string endpoint, IReadOnlyCollection<KeyValuePair<string, string>> payloadStrings, string responseText, DateTime utcValidUntil) {
				this.Endpoint = endpoint;
				this.PayloadStrings = payloadStrings.ToDictionary(p => p.Key, p => p.Value, StringComparer.OrdinalIgnoreCase);
				this.ResponseText = responseText;
				this.UtcValidUntil = utcValidUntil;
			}

			public string Endpoint {
				get;
			}

			public IReadOnlyDictionary<string, string> PayloadStrings {
				get;
			}

			public DateTime UtcValidUntil {
				get;
			}

			public string ResponseText {
				get;
			}

			public bool IsMatch(string endpoint, IReadOnlyCollection<KeyValuePair<string, string>> payloadStrings) {
				if (endpoint != this.Endpoint) {
					return false;
				}
				if (payloadStrings.Count != this.PayloadStrings.Count) {
					return false;
				}
				foreach (var pair in payloadStrings) {
					if (!this.PayloadStrings.TryGetValue(pair.Key, out var value) || pair.Value != value) {
						return false;
					}
				}
				return true;
			}
		}

		private readonly CachedGetRequest[] cache;
		private int index;

		public GetRequestCircularCache(int size = 10, int maxResponseLength = 1024 * 1024, int maxAgeMs = 10000) {
			if (size <= 0) {
				throw new ArgumentOutOfRangeException(nameof(size));
			}
			if (maxResponseLength <= 0) {
				throw new ArgumentOutOfRangeException(nameof(maxResponseLength));
			}
			if (maxAgeMs <= 0) {
				throw new ArgumentOutOfRangeException(nameof(maxAgeMs));
			}
			this.MaxResponseLength = maxResponseLength;
			this.MaxAgeMs = maxAgeMs;
			this.cache = new CachedGetRequest[size];
		}

		public int MaxResponseLength {
			get;
		}

		public int MaxAgeMs {
			get;
		}

		// ReSharper disable once InconsistentlySynchronizedField
		public int Size => this.cache.Length;

		public ValueTask<bool> TryGetCachedAsync(HttpMethod method, string endpoint, IReadOnlyCollection<KeyValuePair<string, string>> payloadStrings, StrongBox<TextReader> response, bool sync) {
			if (method != HttpMethod.Get) {
				return new(false);
			}
			var utcNow = DateTime.UtcNow;
			lock (this.cache) {
				var ix = this.index;
				do {
					var item = this.cache[ix];
					if (item != null) {
						if (item.UtcValidUntil < utcNow) {
							this.cache[ix] = null;
						} else if (item.IsMatch(endpoint, payloadStrings)) {
							response.Value = new StringReader(item.ResponseText);
							return new(true);
						}
					}
					if (ix == 0) {
						ix = this.cache.Length - 1;
					} else {
						ix--;
					}
				} while (ix != this.index);
			}
			return new(false);
		}

		public async ValueTask UpdateCacheAsync(HttpMethod method, string endpoint, IReadOnlyCollection<KeyValuePair<string, string>> payloadStrings, StrongBox<TextReader> response, bool sync) {
			if (method != HttpMethod.Get) {
				// invalidate all cache if the request is not a GET
				this.ClearCache();
				return;
			}
			string responseText;
			using (var reader = response.Value) {
				// ReSharper disable once MethodHasAsyncOverload
				responseText = sync
						? reader.ReadToEnd()
						: await reader.ReadToEndAsync().ConfigureAwait(false);
			}
			response.Value = new StringReader(responseText);
			if (responseText.Length <= this.MaxResponseLength) {
				lock (this.cache) {
					this.cache[this.index] = new(endpoint, payloadStrings, responseText, DateTime.UtcNow.AddMilliseconds(this.MaxAgeMs));
					this.index = (this.index + 1) % this.cache.Length;
				}
			}
		}

		public ValueTask ClearCacheAsync(bool sync) {
			this.ClearCache();
			return default;
		}

		private void ClearCache() {
			lock (this.cache) {
				Array.Clear(this.cache, 0, this.cache.Length);
			}
		}
	}
}
