using System;
using System.IO;
using System.Net.Http;

using bsn.CashCtrl.Http;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static (string ContentType, Stream Stream) OrganizationGetLogo(this CashCtrlClient that) {
			var content = that.Invoke(HttpMethod.Get, "domain/current/logo", null);
			return (content.Headers.ContentType.MediaType, content.ReadAsStream());
		}
	}
}
