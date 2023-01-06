using System.Collections.Generic;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static OrderCategory OrderCategoryRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<OrderCategory>>("order/category/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static OrderCategory[] OrderCategoryList(this CashCtrlClient that, int? fiscalPeriodId, OrderType? type) {
			return that.Get<ListResponse<OrderCategory>>("order/category/list.json", new KeyValuePair<string, object>[] {
					new(nameof(fiscalPeriodId), fiscalPeriodId),
					new(nameof(type), type)
			}).Data;
		}

		public static int OrderCategoryCreate(this CashCtrlClient that, OrderCategory order) {
			return that.Post<CreateResponse>("order/category/create.json", order.ToParameters()).GetInsertIdOrThrow();
		}

		public static void OrderCategoryUpdate(this CashCtrlClient that, OrderCategory order) {
			that.Post<UpdateResponse>("order/category/update.json", order.ToParameters()).EnsureSuccess();
		}

		public static void OrderCategoryDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("order/category/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static void OrderCategoryReorder(this CashCtrlClient that, int[] ids, int target, bool? before, OrderType? type) {
			that.Post<ActionResponse>("order/category/reorder.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids),
					new(nameof(target), target),
					new(nameof(before), before),
					new(nameof(type), type)
			}).EnsureSuccess();
		}

		public static OrderCategoryStatus OrderCategoryStatusRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<OrderCategoryStatus>>("order/category/read_status.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}
	}
}
