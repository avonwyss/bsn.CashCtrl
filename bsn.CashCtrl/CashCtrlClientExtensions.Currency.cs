using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int CurrencyCreate(this CashCtrlClient that, Currency currency) {
			return that.Post<CreateResponse>("currency/create.json", currency.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> CurrencyCreateAsync(this CashCtrlClient that, Currency currency) {
			var response = await that.PostAsync<CreateResponse>("currency/create.json", currency.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void CurrencyDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("currency/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask CurrencyDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("currency/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static double CurrencyExchangerate(this CashCtrlClient that, string from, string to, DateTime? date) {
			var data = that.GetString("currency/exchangerate", new KeyValuePair<string, object>[] {
					new(nameof(from), from), new(nameof(to), to), new(nameof(date), date)
			});
			return double.Parse(data, CultureInfo.InvariantCulture);
		}

		public static async ValueTask<double> CurrencyExchangerateAsync(this CashCtrlClient that, string from, string to, DateTime? date) {
			var data = await that.GetStringAsync("currency/exchangerate", new KeyValuePair<string, object>[] {
					new(nameof(from), from), new(nameof(to), to), new(nameof(date), date)
			}).ConfigureAwait(false);
			return double.Parse(data, CultureInfo.InvariantCulture);
		}

		public static Currency[] CurrencyList(this CashCtrlClient that) {
			return that.Get<ListResponse<Currency>>("currency/list.json", null).Data;
		}

		public static async ValueTask<Currency[]> CurrencyListAsync(this CashCtrlClient that) {
			var response = await that.GetAsync<ListResponse<Currency>>("currency/list.json", null).ConfigureAwait(false);
			return response.Data;
		}

		public static Currency CurrencyRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<Currency>>("currency/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<Currency> CurrencyReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<Currency>>("currency/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void CurrencyUpdate(this CashCtrlClient that, Currency currency) {
			that.Post<UpdateResponse>("currency/update.json", currency.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask CurrencyUpdateAsync(this CashCtrlClient that, Currency currency) {
			var response = await that.PostAsync<UpdateResponse>("currency/update.json", currency.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
