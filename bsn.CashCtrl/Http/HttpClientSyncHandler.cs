using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

using NLog;

namespace bsn.CashCtrl.Http {
	public class HttpClientSyncHandler: HttpClientHandler {
		private static readonly ILogger log = LogManager.GetCurrentClassLogger();

		private static TDelegate GetPrivateMethod<TDelegate>(string name) where TDelegate: Delegate {
			var method = typeof(HttpClientHandler).GetMethod(name, BindingFlags.NonPublic|BindingFlags.Instance);
			if (method == null) {
				return null;
			}
			return (TDelegate)Delegate.CreateDelegate(typeof(TDelegate), method);
		}

		private readonly Func<HttpClientHandler, HttpRequestMessage, HttpWebRequest> CreateAndPrepareWebRequest = GetPrivateMethod<Func<HttpClientHandler, HttpRequestMessage, HttpWebRequest>>(nameof(CreateAndPrepareWebRequest));
		private readonly Func<HttpClientHandler, HttpWebResponse, HttpRequestMessage, HttpResponseMessage> CreateResponseMessage = GetPrivateMethod<Func<HttpClientHandler, HttpWebResponse, HttpRequestMessage, HttpResponseMessage>>(nameof(CreateResponseMessage));

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage, CancellationToken cancellationToken) {
			if (requestMessage == null) {
				throw new ArgumentNullException(nameof(requestMessage), "A request message must be provided. It cannot be null.");
			}
			HttpResponseMessage responseMessage;
			var async = CreateResponseMessage == null || CreateAndPrepareWebRequest == null || !requestMessage.IsSynchronous();
			log.Debug("Request {mode} {method} {uri}", async ? "async" : "sync", requestMessage.Method, requestMessage.RequestUri.GetLeftPart(UriPartial.Path));
			if (async) {
				responseMessage = await base.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);
			} else {
				WindowsIdentity identity = null;
				var webRequest = CreateAndPrepareWebRequest(this, requestMessage);
				if (ExecutionContext.IsFlowSuppressed()) {
					IWebProxy webProxy = null;
					if (UseProxy) {
						webProxy = Proxy ?? WebRequest.DefaultWebProxy;
					}
					if (UseDefaultCredentials || Credentials != null || (webProxy != null && webProxy.Credentials != null)) {
						identity = WindowsIdentity.GetCurrent();
					}
				}
				if (requestMessage.Content != null) {
					var requestContent = requestMessage.Content;
					if (requestMessage.Headers.TransferEncodingChunked.GetValueOrDefault()) {
						webRequest.SendChunked = true;
					} else {
						var stream = requestContent.ReadAsStream();
						webRequest.ContentLength = requestContent.Headers.ContentLength ?? stream.Length;
						Stream requestStream;
						using (identity?.Impersonate()) {
							requestStream = webRequest.GetRequestStream();
						}
						stream.CopyTo(requestStream);
					}
				} else {
					webRequest.ContentLength = 0L;
				}
				HttpWebResponse response;
				try {
					response = (HttpWebResponse)webRequest.GetResponse();
				} catch (WebException ex) {
					response = (HttpWebResponse)ex.Response;
				}
				responseMessage = CreateResponseMessage(this, response, requestMessage);
			}
			log.Debug("Response {mode} {method} {uri}: {status} {reason}", async ? "async" : "sync", requestMessage.Method, requestMessage.RequestUri.GetLeftPart(UriPartial.Path), responseMessage.StatusCode, responseMessage.ReasonPhrase);
			return responseMessage;
		}
	}
}
