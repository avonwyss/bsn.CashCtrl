using System.Collections.Generic;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static FileCategory FileCategoryRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<FileCategory>>("file/category/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static FileCategory[] FileCategoryList(this CashCtrlClient that) {
			return that.Get<ListResponse<FileCategory>>("file/category/list.json", null).Data;
		}

		public static FileCategoryNode[] FileCategoryTree(this CashCtrlClient that) {
			return that.Get<ListResponse<FileCategoryNode>>("file/category/tree.json", null).Data;
		}

		public static int FileCategoryCreate(this CashCtrlClient that, FileCategory file) {
			return that.Post<CreateResponse>("file/category/create.json", file.ToParameters()).GetInsertIdOrThrow();
		}

		public static void FileCategoryUpdate(this CashCtrlClient that, FileCategory file) {
			that.Post<UpdateResponse>("file/category/update.json", file.ToParameters()).EnsureSuccess();
		}

		public static void FileCategoryDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("file/category/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}
	}
}
