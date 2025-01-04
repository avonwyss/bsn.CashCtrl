using System.Collections.Generic;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int FileCategoryCreate(this CashCtrlClient that, FileCategory file) {
			return that.Post<CreateResponse>("file/category/create.json", file.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> FileCategoryCreateAsync(this CashCtrlClient that, FileCategory file) {
			var response = await that.PostAsync<CreateResponse>("file/category/create.json", file.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void FileCategoryDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("file/category/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask FileCategoryDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("file/category/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static FileCategory[] FileCategoryList(this CashCtrlClient that) {
			return that.Get<ListResponse<FileCategory>>("file/category/list.json", null).Data;
		}

		public static async ValueTask<FileCategory[]> FileCategoryListAsync(this CashCtrlClient that) {
			var response = await that.GetAsync<ListResponse<FileCategory>>("file/category/list.json", null).ConfigureAwait(false);
			return response.Data;
		}

		public static FileCategory FileCategoryRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<FileCategory>>("file/category/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<FileCategory> FileCategoryReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<FileCategory>>("file/category/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static FileCategoryNode[] FileCategoryTree(this CashCtrlClient that) {
			return that.Get<ListResponse<FileCategoryNode>>("file/category/tree.json", null).Data;
		}

		public static async ValueTask<FileCategoryNode[]> FileCategoryTreeAsync(this CashCtrlClient that) {
			var response = await that.GetAsync<ListResponse<FileCategoryNode>>("file/category/tree.json", null).ConfigureAwait(false);
			return response.Data;
		}

		public static void FileCategoryUpdate(this CashCtrlClient that, FileCategory file) {
			that.Post<UpdateResponse>("file/category/update.json", file.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask FileCategoryUpdateAsync(this CashCtrlClient that, FileCategory file) {
			var response = await that.PostAsync<UpdateResponse>("file/category/update.json", file.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
