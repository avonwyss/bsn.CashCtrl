using System.Collections.Generic;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int PersonCategoryCreate(this CashCtrlClient that, PersonCategory person) {
			return that.Post<CreateResponse>("person/category/create.json", person.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> PersonCategoryCreateAsync(this CashCtrlClient that, PersonCategory person) {
			var response = await that.PostAsync<CreateResponse>("person/category/create.json", person.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void PersonCategoryDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("person/category/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask PersonCategoryDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("person/category/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static PersonCategory[] PersonCategoryList(this CashCtrlClient that) {
			return that.Get<ListResponse<PersonCategory>>("person/category/list.json", null).Data;
		}

		public static async ValueTask<PersonCategory[]> PersonCategoryListAsync(this CashCtrlClient that) {
			var response = await that.GetAsync<ListResponse<PersonCategory>>("person/category/list.json", null).ConfigureAwait(false);
			return response.Data;
		}

		public static PersonCategory PersonCategoryRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<PersonCategory>>("person/category/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<PersonCategory> PersonCategoryReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<PersonCategory>>("person/category/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static PersonCategoryNode[] PersonCategoryTree(this CashCtrlClient that, int? id) {
			return that.Get<ListResponse<PersonCategoryNode>>("person/category/tree.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).Data;
		}

		public static async ValueTask<PersonCategoryNode[]> PersonCategoryTreeAsync(this CashCtrlClient that, int? id) {
			var response = await that.GetAsync<ListResponse<PersonCategoryNode>>("person/category/tree.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).ConfigureAwait(false);
			return response.Data;
		}

		public static void PersonCategoryUpdate(this CashCtrlClient that, PersonCategory person) {
			that.Post<UpdateResponse>("person/category/update.json", person.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask PersonCategoryUpdateAsync(this CashCtrlClient that, PersonCategory person) {
			var response = await that.PostAsync<UpdateResponse>("person/category/update.json", person.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
