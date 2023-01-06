using System.Collections.Generic;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static PersonTitle PersonTitleRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<PersonTitle>>("person/title/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static PersonTitle[] PersonTitleList(this CashCtrlClient that) {
			return that.Get<ListResponse<PersonTitle>>("person/title/list.json", null).Data;
		}

		public static int PersonTitleCreate(this CashCtrlClient that, PersonTitle person) {
			return that.Post<CreateResponse>("person/title/create.json", person.ToParameters()).GetInsertIdOrThrow();
		}

		public static void PersonTitleUpdate(this CashCtrlClient that, PersonTitle person) {
			that.Post<UpdateResponse>("person/title/update.json", person.ToParameters()).EnsureSuccess();
		}

		public static void PersonTitleDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("person/title/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}
	}
}
