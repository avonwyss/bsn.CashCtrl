using System.Collections.Generic;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static RoundingItem RoundingRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<RoundingItem>>("rounding/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static RoundingItem[] RoundingList(this CashCtrlClient that) {
			return that.Get<ListResponse<RoundingItem>>("rounding/list.json", null).Data;
		}

		public static int RoundingCreate(this CashCtrlClient that, RoundingItem rounding) {
			return that.Post<CreateResponse>("rounding/create.json", rounding.ToParameters()).GetInsertIdOrThrow();
		}

		public static void RoundingUpdate(this CashCtrlClient that, RoundingItem rounding) {
			that.Post<UpdateResponse>("rounding/update.json", rounding.ToParameters()).EnsureSuccess();
		}

		public static void RoundingDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("rounding/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}
	}
}
