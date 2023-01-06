using System.Collections.Generic;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static Tax TaxRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<Tax>>("tax/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static Tax[] TaxList(this CashCtrlClient that) {
			return that.Get<ListResponse<Tax>>("tax/list.json", null).Data;
		}

		public static int TaxCreate(this CashCtrlClient that, Tax tax) {
			return that.Post<CreateResponse>("tax/create.json", tax.ToParameters()).GetInsertIdOrThrow();
		}

		public static void TaxUpdate(this CashCtrlClient that, Tax tax) {
			that.Post<UpdateResponse>("tax/update.json", tax.ToParameters()).EnsureSuccess();
		}

		public static void TaxDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("tax/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}
	}
}
