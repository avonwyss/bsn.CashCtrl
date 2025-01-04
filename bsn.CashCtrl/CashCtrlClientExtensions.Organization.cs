using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

using bsn.HttpClientSync;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static (string ContentType, Stream Stream) OrganizationGetLogo(this CashCtrlClient that) {
			var content = that.Invoke(HttpMethod.Get, "domain/current/logo", null);
			return (content.Headers.ContentType.MediaType, content.ReadAsStream());
		}

		public static async ValueTask<(string ContentType, Stream Stream)> OrganizationGetLogoAsync(this CashCtrlClient that) {
			var content = await that.InvokeAsync(HttpMethod.Get, "domain/current/logo", null).ConfigureAwait(false);
			return (content.Headers.ContentType.MediaType, await content.ReadAsStreamAsync().ConfigureAwait(false));
		}
	}
}
