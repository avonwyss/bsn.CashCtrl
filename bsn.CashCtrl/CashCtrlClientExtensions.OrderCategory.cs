using System.Collections.Generic;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int OrderCategoryCreate(this CashCtrlClient that, OrderCategory order) {
			return that.Post<CreateResponse>("order/category/create.json", order.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> OrderCategoryCreateAsync(this CashCtrlClient that, OrderCategory order) {
			var response = await that.PostAsync<CreateResponse>("order/category/create.json", order.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void OrderCategoryDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("order/category/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask OrderCategoryDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("order/category/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static OrderCategory[] OrderCategoryList(this CashCtrlClient that, int? fiscalPeriodId = default, OrderType? type = default) {
			return that.Get<ListResponse<OrderCategory>>("order/category/list.json", new KeyValuePair<string, object>[] {
					new(nameof(fiscalPeriodId), fiscalPeriodId),
					new(nameof(type), type)
			}).Data;
		}

		public static async ValueTask<OrderCategory[]> OrderCategoryListAsync(this CashCtrlClient that, int? fiscalPeriodId = default, OrderType? type = default) {
			var response = await that.GetAsync<ListResponse<OrderCategory>>("order/category/list.json", new KeyValuePair<string, object>[] {
					new(nameof(fiscalPeriodId), fiscalPeriodId),
					new(nameof(type), type)
			}).ConfigureAwait(false);
			return response.Data;
		}

		public static OrderCategory OrderCategoryRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<OrderCategory>>("order/category/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<OrderCategory> OrderCategoryReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<OrderCategory>>("order/category/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void OrderCategoryReorder(this CashCtrlClient that, int[] ids, int target, bool? before, OrderType? type) {
			that.Post<ActionResponse>("order/category/reorder.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids),
					new(nameof(target), target),
					new(nameof(before), before),
					new(nameof(type), type)
			}).EnsureSuccess();
		}

		public static async ValueTask OrderCategoryReorderAsync(this CashCtrlClient that, int[] ids, int target, bool? before, OrderType? type) {
			var response = await that.PostAsync<ActionResponse>("order/category/reorder.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids),
					new(nameof(target), target),
					new(nameof(before), before),
					new(nameof(type), type)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static OrderCategoryStatus OrderCategoryStatusRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<OrderCategoryStatus>>("order/category/read_status.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<OrderCategoryStatus> OrderCategoryStatusReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<OrderCategoryStatus>>("order/category/read_status.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void OrderCategoryUpdate(this CashCtrlClient that, OrderCategory order) {
			that.Post<UpdateResponse>("order/category/update.json", order.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask OrderCategoryUpdateAsync(this CashCtrlClient that, OrderCategory order) {
			var response = await that.PostAsync<UpdateResponse>("order/category/update.json", order.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
