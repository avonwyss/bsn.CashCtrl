using System.Collections.Generic;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static AccountCostCenterCategory AccountCostCenterCategoryRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<AccountCostCenterCategory>>("account/costcenter/category/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static AccountCostCenterCategory[] AccountCostCenterCategoryList(this CashCtrlClient that) {
			return that.Get<ListResponse<AccountCostCenterCategory>>("account/costcenter/category/list.json", null).Data;
		}

		public static AccountCostCenterCategoryNode[] AccountCostCenterCategoryTree(this CashCtrlClient that, int? id) {
			return that.Get<ListResponse<AccountCostCenterCategoryNode>>("account/costcenter/category/tree.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).Data;
		}

		public static int AccountCostCenterCategoryCreate(this CashCtrlClient that, AccountCostCenterCategory account) {
			return that.Post<CreateResponse>("account/costcenter/category/create.json", account.ToParameters()).GetInsertIdOrThrow();
		}

		public static void AccountCostCenterCategoryUpdate(this CashCtrlClient that, AccountCostCenterCategory account) {
			that.Post<UpdateResponse>("account/costcenter/category/update.json", account.ToParameters()).EnsureSuccess();
		}

		public static void AccountCostCenterCategoryDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("account/costcenter/category/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}
	}
}
