using System;
using System.Collections.Generic;
using System.Globalization;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static Currency CurrencyRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<Currency>>("currency/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static Currency[] CurrencyList(this CashCtrlClient that) {
			return that.Get<ListResponse<Currency>>("currency/list.json", null).Data;
		}

		public static int CurrencyCreate(this CashCtrlClient that, Currency currency) {
			return that.Post<CreateResponse>("currency/create.json", currency.ToParameters()).GetInsertIdOrThrow();
		}

		public static void CurrencyUpdate(this CashCtrlClient that, Currency currency) {
			that.Post<UpdateResponse>("currency/update.json", currency.ToParameters()).EnsureSuccess();
		}

		public static void CurrencyDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("currency/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static double CurrencyExchangerate(this CashCtrlClient that, string from, string to, DateTime? date) {
			var data = that.GetString($"currency/exchangerate", new KeyValuePair<string, object>[] {
					new(nameof(from), from),
					new(nameof(to), to),
					new(nameof(date), date)
			});
			return double.Parse(data, CultureInfo.InvariantCulture);
		}
	}
}
