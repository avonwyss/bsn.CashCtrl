using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;
using bsn.HttpClientSync;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static void OrderDocumentMail(this CashCtrlClient that, int[] orderIds, string mailFrom, string mailTo, string mailCc, string mailBcc, string mailSubject, string mailText, bool? isCopyToMe, int? sentStatusId) {
			that.Get<ActionResponse>("order/document/mail.json", new KeyValuePair<string, object>[] {
					new(nameof(orderIds), orderIds),
					new(nameof(mailFrom), mailFrom),
					new(nameof(mailTo), mailTo),
					new(nameof(mailCc), mailCc),
					new(nameof(mailBcc), mailBcc),
					new(nameof(mailSubject), mailSubject),
					new(nameof(mailText), mailText),
					new(nameof(isCopyToMe), isCopyToMe),
					new(nameof(sentStatusId), sentStatusId)
			}).EnsureSuccess();
		}

		public static async ValueTask OrderDocumentMailAsync(this CashCtrlClient that, int[] orderIds, string mailFrom, string mailTo, string mailCc, string mailBcc, string mailSubject, string mailText, bool? isCopyToMe, int? sentStatusId) {
			var response = await that.GetAsync<ActionResponse>("order/document/mail.json", new KeyValuePair<string, object>[] {
					new(nameof(orderIds), orderIds),
					new(nameof(mailFrom), mailFrom),
					new(nameof(mailTo), mailTo),
					new(nameof(mailCc), mailCc),
					new(nameof(mailBcc), mailBcc),
					new(nameof(mailSubject), mailSubject),
					new(nameof(mailText), mailText),
					new(nameof(isCopyToMe), isCopyToMe),
					new(nameof(sentStatusId), sentStatusId)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static OrderDocument OrderDocumentRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<OrderDocument>>("order/document/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static Stream OrderDocumentRead(this CashCtrlClient that, CashCtrlDocumentFormat format, int id) {
			return that.Get($"order/document/read.{format.ToString().ToLowerInvariant()}", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).ReadAsStream();
		}

		public static async ValueTask<OrderDocument> OrderDocumentReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<OrderDocument>>("order/document/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static async ValueTask<Stream> OrderDocumentReadAsync(this CashCtrlClient that, CashCtrlDocumentFormat format, int id) {
			var content = await that.GetAsync($"order/document/read.{format.ToString().ToLowerInvariant()}", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).ConfigureAwait(false);
			return await content.ReadAsStreamAsync().ConfigureAwait(false);
		}

		public static void OrderDocumentUpdate(this CashCtrlClient that, OrderDocument orderDocument) {
			that.Post<UpdateResponse>("order/document/update.json", orderDocument.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask OrderDocumentUpdateAsync(this CashCtrlClient that, OrderDocument orderDocument) {
			var response = await that.PostAsync<UpdateResponse>("order/document/update.json", orderDocument.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
