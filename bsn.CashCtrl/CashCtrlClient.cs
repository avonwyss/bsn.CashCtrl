using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

using bsn.CashCtrl.Response;
using bsn.HttpClientSync;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace bsn.CashCtrl {
	public class CashCtrlClient: IDisposable {
		internal const string EntityFieldIsReadonly = "The field of the entity is read-only on the client.";
		internal const string EntityFieldMissing = "The field of the entity is not returned by the server.";
		internal const string EntityFieldAlwaysNull = "The field is always null.";

		private static readonly Regex RxMethodWithoutBody = new("^(HEAD|GET|DELETE|OPTIONS|TRACE)$", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

		private static string Encode(string data) {
			return string.IsNullOrEmpty(data) ? string.Empty : Uri.EscapeDataString(data).Replace("%20", "+");
		}

		private static HttpClient CreateHttpClient(bool async) {
			return new(new RetryHandler(10, async
					? new HttpClientHandler() {
							AllowAutoRedirect = true
					}
					: new HttpClientSyncHandler() {
							AllowAutoRedirect = true
					}));
		}

		private readonly Uri baseUri;
		private readonly HttpClient httpClient;

		private readonly JsonSerializer jsonSerializer = JsonSerializer.Create(new() {
				DateFormatString = CashCtrlClientExtensions.CashCtrlDateTimeFormat,
				NullValueHandling = NullValueHandling.Ignore,
				CheckAdditionalContent = false,
				Formatting = Formatting.None,
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				Converters = new List<JsonConverter> { new UppercaseStringEnumConverter(), new LocalizedStringConverter() }
		});

		private readonly AuthenticationHeaderValue authorization;

		public CashCtrlClient(string domain, string apiKey): this(domain, apiKey, false) { }

		public CashCtrlClient(string domain, string apiKey, bool async): this(new(FormattableString.Invariant($"https://{Uri.EscapeDataString(domain.ToLowerInvariant())}.cashctrl.com/api/v1/")), apiKey, CreateHttpClient(async)) { }

		internal CashCtrlClient(Uri baseUri, string apiKey, HttpClient httpClient) {
			this.baseUri = baseUri;
			this.httpClient = httpClient;
			this.authorization = new("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(apiKey + ':')));
		}

		public void Dispose() {
			this.httpClient.Dispose();
		}

		internal HttpClient HttpClient => this.httpClient;

		public JsonSerializer JsonSerializer => this.jsonSerializer;

		private T ConvertResult<T>(JToken result) {
			if (typeof(T).IsAssignableFrom(typeof(JToken))) {
				return (T)(object)result;
			}
			using var reader = new JTokenReader(result);
			return this.jsonSerializer.Deserialize<T>(reader);
		}

		public HttpContent Invoke(HttpMethod method, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters) {
			var request = this.PrepareRequest(method, endpoint, parameters);
			string content = null;
			try {
				var response = this.httpClient.Send(request);
				if (!response.IsSuccessStatusCode && response.Content != null) {
					try {
						content = response.Content.ReadAsString();
					} catch (Exception ex) {
						content = $"Response content could not be loaded: {ex.Message}";
					}
				}
				response.EnsureSuccessStatusCode();
				return response.Content;
			} catch (Exception ex) {
				throw new CashCtrlApiException(ex.Message, ex, content);
			}
		}

		public JObject InvokeJson(HttpMethod method, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters) {
			using var textReader = this.InvokeTextReader(method, endpoint, parameters);
			using var jsonReader = new JsonTextReader(textReader);
			var jsonContent = JObject.Load(jsonReader);
			return jsonContent;
		}

		public StreamReader InvokeTextReader(HttpMethod method, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters) {
			var content = this.Invoke(method, endpoint, parameters);
			var charSet = content.Headers.ContentType?.CharSet;
			var stream = content.ReadAsStream();
			return new(stream, string.IsNullOrEmpty(charSet) ? Encoding.UTF8 : Encoding.GetEncoding(charSet));
		}

		public T InvokeJson<T>(HttpMethod method, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters) {
			return this.ConvertResult<T>(this.InvokeJson(method, endpoint, parameters));
		}

		public async ValueTask<HttpContent> InvokeAsync(HttpMethod method, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters, CancellationToken cancellationToken = default) {
			var request = this.PrepareRequest(method, endpoint, parameters);
			string content = null;
			try {
				var response = await this.httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
				if (!response.IsSuccessStatusCode && response.Content != null) {
					try {
						content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
					} catch (Exception ex) {
						content = $"Response content could not be loaded: {ex.Message}";
					}
				}
				response.EnsureSuccessStatusCode();
				return response.Content;
			} catch (Exception ex) {
				throw new CashCtrlApiException(ex.Message, ex, content);
			}
		}

		public async ValueTask<JObject> InvokeJsonAsync(HttpMethod method, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters, CancellationToken cancellationToken = default) {
			using var textReader = await this.InvokeTextReaderAsync(method, endpoint, parameters, cancellationToken).ConfigureAwait(false);
			using var jsonReader = new JsonTextReader(textReader);
			var jsonContent = await JObject.LoadAsync(jsonReader, cancellationToken).ConfigureAwait(false);
			return jsonContent;
		}

		public async ValueTask<StreamReader> InvokeTextReaderAsync(HttpMethod method, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters, CancellationToken cancellationToken = default) {
			var content = await this.InvokeAsync(method, endpoint, parameters, cancellationToken).ConfigureAwait(false);
			var charSet = content.Headers.ContentType?.CharSet;
			var stream = await content.ReadAsStreamAsync().ConfigureAwait(false);
			return new(stream, string.IsNullOrEmpty(charSet) ? Encoding.UTF8 : Encoding.GetEncoding(charSet));
		}

		public async ValueTask<T> InvokeJsonAsync<T>(HttpMethod method, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters, CancellationToken cancellationToken = default) {
			return this.ConvertResult<T>(await this.InvokeJsonAsync(method, endpoint, parameters, cancellationToken).ConfigureAwait(false));
		}

		private HttpRequestMessage PrepareRequest(HttpMethod method, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters) {
			var payloadStrings = parameters?
					.Where(p => p.Value != null)
					.Select(p => new KeyValuePair<string, string>(p.Key, this.SerializeToString(p.Value)));
			var payloadAsQuery = RxMethodWithoutBody.IsMatch(method.Method);
			if (payloadStrings != null && payloadAsQuery) {
				// ReSharper disable once PossibleMultipleEnumeration
				endpoint += (endpoint.IndexOf('?') < 0 ? '?' : '&') + string.Join("&", payloadStrings.Select(p => Encode(p.Key) + "=" + Encode(p.Value)));
			}
			var request = new HttpRequestMessage(method, new Uri(this.baseUri, endpoint));
			request.Headers.Authorization = this.authorization;
			if (payloadStrings != null && !payloadAsQuery) {
				// ReSharper disable once PossibleMultipleEnumeration
				request.Content = new FormUrlEncodedContent(payloadStrings);
			}
			return request;
		}

		private string JsonToString(object value) {
			using var writer = new StringWriter();
			this.jsonSerializer.Serialize(writer, value);
			return writer.ToString();
		}

		private string SerializeToString(object value) {
			return value switch {
					null => string.Empty,
					var o when o.GetType().IsEnum => UppercaseStringEnumConverter.EnumValueToString(o),
					LocalizedString str => (string)str,
					IApiSerializable serializable => this.SerializeToString(this.SerializeToJObject(serializable)),
					JValue jValue => this.SerializeToString(jValue.Value),
					JContainer jContainer => this.JsonToString(jContainer),
					XNode xNode => xNode.ToString(SaveOptions.DisableFormatting | SaveOptions.OmitDuplicateNamespaces),
					string str => str,
					bool b => b ? "1" : "0",
					DateTime dt => dt.ToCashCtrlString(),
					IFormattable formattable => formattable.ToString(null, CultureInfo.InvariantCulture),
					IEnumerable<IApiSerializable> enumerable => '[' + string.Join(",", enumerable.Select(this.SerializeToString)) + ']',
					IEnumerable<JToken> enumerable => '[' + string.Join(",", enumerable.Select(this.SerializeToString)) + ']',
					IEnumerable enumerable => string.Join(",", enumerable.Cast<object>().Select(this.SerializeToString)),
					_ => throw new NotSupportedException("Data type " + value.GetType().Name + " is not supported for parameter serialization")
			};
		}

		private JToken SerializeToJToken(object obj) {
			return obj switch {
					JToken token => token,
					IApiSerializable serializable => this.SerializeToJObject(serializable),
					string str => new JValue(str),
					IEnumerable enumerable => new JArray(enumerable.Cast<object>().Select(this.SerializeToJToken)),
					_ => new JValue(this.SerializeToString(obj))
			};
		}

		private JObject SerializeToJObject(IApiSerializable serializable) {
			return new (serializable
					.ToParameters()
					.Select(p => new JProperty(p.Key, this.SerializeToJToken(p.Value))));
		}
	}
}
