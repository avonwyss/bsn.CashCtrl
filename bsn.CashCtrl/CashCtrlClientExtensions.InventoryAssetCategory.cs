using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int InventoryAssetCategoryCreate(this CashCtrlClient that, InventoryAssetCategory file) {
			return that.Post<CreateResponse>("inventory/asset/category/create.json", file.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> InventoryAssetCategoryCreateAsync(this CashCtrlClient that, InventoryAssetCategory file) {
			var response = await that.PostAsync<CreateResponse>("inventory/asset/category/create.json", file.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void InventoryAssetCategoryDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("inventory/asset/category/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask InventoryAssetCategoryDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("inventory/asset/category/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		[Obsolete("As of 2024, this method returns the article categories instead of the asset categories.", false)]
		public static InventoryAssetCategory[] InventoryAssetCategoryList(this CashCtrlClient that) {
			return that.Get<ListResponse<InventoryAssetCategory>>("inventory/asset/category/list.json", null).Data;
		}

		[Obsolete("As of 2024, this method returns the article categories instead of the asset categories.", false)]
		public static async ValueTask<InventoryAssetCategory[]> InventoryAssetCategoryListAsync(this CashCtrlClient that) {
			var response = await that.GetAsync<ListResponse<InventoryAssetCategory>>("inventory/asset/category/list.json", null).ConfigureAwait(false);
			return response.Data;
		}

		[Obsolete("As of 2024, this method returns the article category instead of the asset category.", false)]
		public static InventoryAssetCategory InventoryAssetCategoryRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<InventoryAssetCategory>>("inventory/asset/category/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		[Obsolete("As of 2024, this method returns the article category instead of the asset category.", false)]
		public static async ValueTask<InventoryAssetCategory> InventoryAssetCategoryReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<InventoryAssetCategory>>("inventory/asset/category/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static InventoryAssetCategoryNode[] InventoryAssetCategoryTree(this CashCtrlClient that, int? id = default) {
			return that.Get<ListResponse<InventoryAssetCategoryNode>>("inventory/asset/category/tree.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).Data;
		}

		public static async ValueTask<InventoryAssetCategoryNode[]> InventoryAssetCategoryTreeAsync(this CashCtrlClient that, int? id = default) {
			var response = await that.GetAsync<ListResponse<InventoryAssetCategoryNode>>("inventory/asset/category/tree.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).ConfigureAwait(false);
			return response.Data;
		}

		public static void InventoryAssetCategoryUpdate(this CashCtrlClient that, InventoryAssetCategory file) {
			that.Post<UpdateResponse>("inventory/asset/category/update.json", file.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask InventoryAssetCategoryUpdateAsync(this CashCtrlClient that, InventoryAssetCategory file) {
			var response = await that.PostAsync<UpdateResponse>("inventory/asset/category/update.json", file.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
