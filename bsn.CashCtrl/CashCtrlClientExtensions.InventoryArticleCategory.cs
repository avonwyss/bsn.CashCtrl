using System.Collections.Generic;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static InventoryArticleCategory InventoryArticleCategoryRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<InventoryArticleCategory>>("inventory/article/category/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static InventoryArticleCategory[] InventoryArticleCategoryList(this CashCtrlClient that) {
			return that.Get<ListResponse<InventoryArticleCategory>>("inventory/article/category/list.json", null).Data;
		}

		public static InventoryArticleCategoryNode[] InventoryArticleCategoryTree(this CashCtrlClient that, int? id=default) {
			return that.Get<ListResponse<InventoryArticleCategoryNode>>("inventory/article/category/tree.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).Data;
		}

		public static int InventoryArticleCategoryCreate(this CashCtrlClient that, InventoryArticleCategory file) {
			return that.Post<CreateResponse>("inventory/article/category/create.json", file.ToParameters()).GetInsertIdOrThrow();
		}

		public static void InventoryArticleCategoryUpdate(this CashCtrlClient that, InventoryArticleCategory file) {
			that.Post<UpdateResponse>("inventory/article/category/update.json", file.ToParameters()).EnsureSuccess();
		}

		public static void InventoryArticleCategoryDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("inventory/article/category/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}
	}
}
