using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace bsn.CashCtrl.Http {
	public static class HttpClientSyncExtensions {
		private const string SynchronousPropertyKey = "Synchronous";

		public static HttpResponseMessage Send(this HttpClient that, HttpRequestMessage request, HttpCompletionOption completionOption = default, CancellationToken cancellationToken = default) {
			request.Properties[SynchronousPropertyKey] = true;
			return that.SendAsync(request, completionOption, cancellationToken).GetAwaiter().GetResult();
		}

		public static Stream ReadAsStream(this HttpContent that, TransportContext context = default) {
			return that.ReadAsStreamAsync().GetAwaiter().GetResult();
		}

		public static bool IsSynchronous(this HttpRequestMessage that) {
			return (that.Properties.TryGetValue(HttpClientSyncExtensions.SynchronousPropertyKey, out var sync) && true.Equals(sync));
		}
	}
}
