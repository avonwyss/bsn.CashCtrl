using System.Collections.Generic;
using System.IO;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Http;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
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

		public static void OrderDocumentUpdate(this CashCtrlClient that, OrderDocument orderDocument) {
			that.Post<UpdateResponse>("order/document/update.json", orderDocument.ToParameters()).EnsureSuccess();
		}
	}
}
