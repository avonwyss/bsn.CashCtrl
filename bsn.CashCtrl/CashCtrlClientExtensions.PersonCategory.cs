using System.Collections.Generic;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static PersonCategory PersonCategoryRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<PersonCategory>>("person/category/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static PersonCategory[] PersonCategoryList(this CashCtrlClient that) {
			return that.Get<ListResponse<PersonCategory>>("person/category/list.json", null).Data;
		}

		public static PersonCategoryNode[] PersonCategoryTree(this CashCtrlClient that, int? id) {
			return that.Get<ListResponse<PersonCategoryNode>>("person/category/tree.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).Data;
		}

		public static int PersonCategoryCreate(this CashCtrlClient that, PersonCategory person) {
			return that.Post<CreateResponse>("person/category/create.json", person.ToParameters()).GetInsertIdOrThrow();
		}

		public static void PersonCategoryUpdate(this CashCtrlClient that, PersonCategory person) {
			that.Post<UpdateResponse>("person/category/update.json", person.ToParameters()).EnsureSuccess();
		}

		public static void PersonCategoryDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("person/category/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}
	}
}
