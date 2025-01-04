using System.Collections.Generic;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int TaxCreate(this CashCtrlClient that, Tax tax) {
			return that.Post<CreateResponse>("tax/create.json", tax.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> TaxCreateAsync(this CashCtrlClient that, Tax tax) {
			var response = await that.PostAsync<CreateResponse>("tax/create.json", tax.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void TaxDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("tax/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask TaxDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("tax/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static Tax[] TaxList(this CashCtrlClient that) {
			return that.Get<ListResponse<Tax>>("tax/list.json", null).Data;
		}

		public static async ValueTask<Tax[]> TaxListAsync(this CashCtrlClient that) {
			var response = await that.GetAsync<ListResponse<Tax>>("tax/list.json", null).ConfigureAwait(false);
			return response.Data;
		}

		public static Tax TaxRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<Tax>>("tax/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<Tax> TaxReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<Tax>>("tax/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void TaxUpdate(this CashCtrlClient that, Tax tax) {
			that.Post<UpdateResponse>("tax/update.json", tax.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask TaxUpdateAsync(this CashCtrlClient that, Tax tax) {
			var response = await that.PostAsync<UpdateResponse>("tax/update.json", tax.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
