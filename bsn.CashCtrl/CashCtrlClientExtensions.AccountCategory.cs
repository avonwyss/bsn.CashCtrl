using System.Collections.Generic;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int AccountCategoryCreate(this CashCtrlClient that, AccountCategory account) {
			return that.Post<CreateResponse>("account/category/create.json", account.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> AccountCategoryCreateAsync(this CashCtrlClient that, AccountCategory account) {
			var response = await that.PostAsync<CreateResponse>("account/category/create.json", account.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void AccountCategoryDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("account/category/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask AccountCategoryDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("account/category/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static AccountCategory[] AccountCategoryList(this CashCtrlClient that) {
			return that.Get<ListResponse<AccountCategory>>("account/category/list.json", null).Data;
		}

		public static async ValueTask<AccountCategory[]> AccountCategoryListAsync(this CashCtrlClient that) {
			var response = await that.GetAsync<ListResponse<AccountCategory>>("account/category/list.json", null).ConfigureAwait(false);
			return response.Data;
		}

		public static AccountCategory AccountCategoryRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<AccountCategory>>("account/category/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<AccountCategory> AccountCategoryReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<AccountCategory>>("account/category/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static AccountCategoryNode[] AccountCategoryTree(this CashCtrlClient that, int? id) {
			return that.Get<ListResponse<AccountCategoryNode>>("account/category/tree.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).Data;
		}

		public static async ValueTask<AccountCategoryNode[]> AccountCategoryTreeAsync(this CashCtrlClient that, int? id) {
			var response = await that.GetAsync<ListResponse<AccountCategoryNode>>("account/category/tree.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).ConfigureAwait(false);
			return response.Data;
		}

		public static void AccountCategoryUpdate(this CashCtrlClient that, AccountCategory account) {
			that.Post<UpdateResponse>("account/category/update.json", account.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask AccountCategoryUpdateAsync(this CashCtrlClient that, AccountCategory account) {
			var response = await that.PostAsync<UpdateResponse>("account/category/update.json", account.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
