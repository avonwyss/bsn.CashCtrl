using System.Collections.Generic;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int InventoryArticleCategoryCreate(this CashCtrlClient that, InventoryArticleCategory file) {
			return that.Post<CreateResponse>("inventory/article/category/create.json", file.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> InventoryArticleCategoryCreateAsync(this CashCtrlClient that, InventoryArticleCategory file) {
			var response = await that.PostAsync<CreateResponse>("inventory/article/category/create.json", file.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void InventoryArticleCategoryDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("inventory/article/category/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask InventoryArticleCategoryDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("inventory/article/category/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static InventoryArticleCategory[] InventoryArticleCategoryList(this CashCtrlClient that) {
			return that.Get<ListResponse<InventoryArticleCategory>>("inventory/article/category/list.json", null).Data;
		}

		public static async ValueTask<InventoryArticleCategory[]> InventoryArticleCategoryListAsync(this CashCtrlClient that) {
			var response = await that.GetAsync<ListResponse<InventoryArticleCategory>>("inventory/article/category/list.json", null).ConfigureAwait(false);
			return response.Data;
		}

		public static InventoryArticleCategory InventoryArticleCategoryRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<InventoryArticleCategory>>("inventory/article/category/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<InventoryArticleCategory> InventoryArticleCategoryReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<InventoryArticleCategory>>("inventory/article/category/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static InventoryArticleCategoryNode[] InventoryArticleCategoryTree(this CashCtrlClient that, int? id = default) {
			return that.Get<ListResponse<InventoryArticleCategoryNode>>("inventory/article/category/tree.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).Data;
		}

		public static async ValueTask<InventoryArticleCategoryNode[]> InventoryArticleCategoryTreeAsync(this CashCtrlClient that, int? id = default) {
			var response = await that.GetAsync<ListResponse<InventoryArticleCategoryNode>>("inventory/article/category/tree.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).ConfigureAwait(false);
			return response.Data;
		}

		public static void InventoryArticleCategoryUpdate(this CashCtrlClient that, InventoryArticleCategory file) {
			that.Post<UpdateResponse>("inventory/article/category/update.json", file.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask InventoryArticleCategoryUpdateAsync(this CashCtrlClient that, InventoryArticleCategory file) {
			var response = await that.PostAsync<UpdateResponse>("inventory/article/category/update.json", file.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
