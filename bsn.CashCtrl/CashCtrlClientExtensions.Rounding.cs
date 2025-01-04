using System.Collections.Generic;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int RoundingCreate(this CashCtrlClient that, RoundingItem rounding) {
			return that.Post<CreateResponse>("rounding/create.json", rounding.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> RoundingCreateAsync(this CashCtrlClient that, RoundingItem rounding) {
			var response = await that.PostAsync<CreateResponse>("rounding/create.json", rounding.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void RoundingDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("rounding/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask RoundingDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("rounding/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static RoundingItem[] RoundingList(this CashCtrlClient that) {
			return that.Get<ListResponse<RoundingItem>>("rounding/list.json", null).Data;
		}

		public static async ValueTask<RoundingItem[]> RoundingListAsync(this CashCtrlClient that) {
			var response = await that.GetAsync<ListResponse<RoundingItem>>("rounding/list.json", null).ConfigureAwait(false);
			return response.Data;
		}

		public static RoundingItem RoundingRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<RoundingItem>>("rounding/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<RoundingItem> RoundingReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<RoundingItem>>("rounding/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void RoundingUpdate(this CashCtrlClient that, RoundingItem rounding) {
			that.Post<UpdateResponse>("rounding/update.json", rounding.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask RoundingUpdateAsync(this CashCtrlClient that, RoundingItem rounding) {
			var response = await that.PostAsync<UpdateResponse>("rounding/update.json", rounding.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
