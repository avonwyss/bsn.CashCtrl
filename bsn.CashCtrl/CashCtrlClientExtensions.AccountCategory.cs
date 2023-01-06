using System.Collections.Generic;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static AccountCategory AccountCategoryRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<AccountCategory>>("account/category/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static AccountCategory[] AccountCategoryList(this CashCtrlClient that) {
			return that.Get<ListResponse<AccountCategory>>("account/category/list.json", null).Data;
		}

		public static AccountCategoryNode[] AccountCategoryTree(this CashCtrlClient that, int? id) {
			return that.Get<ListResponse<AccountCategoryNode>>("account/category/tree.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).Data;
		}

		public static int AccountCategoryCreate(this CashCtrlClient that, AccountCategory account) {
			return that.Post<CreateResponse>("account/category/create.json", account.ToParameters()).GetInsertIdOrThrow();
		}

		public static void AccountCategoryUpdate(this CashCtrlClient that, AccountCategory account) {
			that.Post<UpdateResponse>("account/category/update.json", account.ToParameters()).EnsureSuccess();
		}

		public static void AccountCategoryDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("account/category/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}
	}
}
