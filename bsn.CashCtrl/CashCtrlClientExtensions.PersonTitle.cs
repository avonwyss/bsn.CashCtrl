using System.Collections.Generic;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int PersonTitleCreate(this CashCtrlClient that, PersonTitle person) {
			return that.Post<CreateResponse>("person/title/create.json", person.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> PersonTitleCreateAsync(this CashCtrlClient that, PersonTitle person) {
			var response = await that.PostAsync<CreateResponse>("person/title/create.json", person.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void PersonTitleDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("person/title/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask PersonTitleDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("person/title/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static PersonTitle[] PersonTitleList(this CashCtrlClient that) {
			return that.Get<ListResponse<PersonTitle>>("person/title/list.json", null).Data;
		}

		public static async ValueTask<PersonTitle[]> PersonTitleListAsync(this CashCtrlClient that) {
			var response = await that.GetAsync<ListResponse<PersonTitle>>("person/title/list.json", null).ConfigureAwait(false);
			return response.Data;
		}

		public static PersonTitle PersonTitleRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<PersonTitle>>("person/title/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<PersonTitle> PersonTitleReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<PersonTitle>>("person/title/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void PersonTitleUpdate(this CashCtrlClient that, PersonTitle person) {
			that.Post<UpdateResponse>("person/title/update.json", person.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask PersonTitleUpdateAsync(this CashCtrlClient that, PersonTitle person) {
			var response = await that.PostAsync<UpdateResponse>("person/title/update.json", person.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
