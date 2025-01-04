using System.Collections.Generic;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int AccountCostCenterCategoryCreate(this CashCtrlClient that, AccountCostCenterCategory account) {
			return that.Post<CreateResponse>("account/costcenter/category/create.json", account.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> AccountCostCenterCategoryCreateAsync(this CashCtrlClient that, AccountCostCenterCategory account) {
			var response = await that.PostAsync<CreateResponse>("account/costcenter/category/create.json", account.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void AccountCostCenterCategoryDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("account/costcenter/category/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask AccountCostCenterCategoryDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("account/costcenter/category/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static AccountCostCenterCategory[] AccountCostCenterCategoryList(this CashCtrlClient that) {
			return that.Get<ListResponse<AccountCostCenterCategory>>("account/costcenter/category/list.json", null).Data;
		}

		public static async ValueTask<AccountCostCenterCategory[]> AccountCostCenterCategoryListAsync(this CashCtrlClient that) {
			var response = await that.GetAsync<ListResponse<AccountCostCenterCategory>>("account/costcenter/category/list.json", null).ConfigureAwait(false);
			return response.Data;
		}

		public static AccountCostCenterCategory AccountCostCenterCategoryRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<AccountCostCenterCategory>>("account/costcenter/category/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<AccountCostCenterCategory> AccountCostCenterCategoryReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<AccountCostCenterCategory>>("account/costcenter/category/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static AccountCostCenterCategoryNode[] AccountCostCenterCategoryTree(this CashCtrlClient that, int? id) {
			return that.Get<ListResponse<AccountCostCenterCategoryNode>>("account/costcenter/category/tree.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).Data;
		}

		public static async ValueTask<AccountCostCenterCategoryNode[]> AccountCostCenterCategoryTreeAsync(this CashCtrlClient that, int? id) {
			var response = await that.GetAsync<ListResponse<AccountCostCenterCategoryNode>>("account/costcenter/category/tree.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).ConfigureAwait(false);
			return response.Data;
		}

		public static void AccountCostCenterCategoryUpdate(this CashCtrlClient that, AccountCostCenterCategory account) {
			that.Post<UpdateResponse>("account/costcenter/category/update.json", account.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask AccountCostCenterCategoryUpdateAsync(this CashCtrlClient that, AccountCostCenterCategory account) {
			var response = await that.PostAsync<UpdateResponse>("account/costcenter/category/update.json", account.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
