using System;
using System.Collections.Generic;
using System.Globalization;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static Fiscalperiod FiscalperiodRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<Fiscalperiod>>("fiscalperiod/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static Fiscalperiod[] FiscalperiodList(this CashCtrlClient that) {
			return that.Get<ListResponse<Fiscalperiod>>("fiscalperiod/list.json", null).Data;
		}

		public static int FiscalperiodCreate(this CashCtrlClient that, Fiscalperiod fiscalperiod) {
			return that.Post<CreateResponse>("fiscalperiod/create.json", fiscalperiod.ToParameters()).GetInsertIdOrThrow();
		}

		public static void FiscalperiodUpdate(this CashCtrlClient that, Fiscalperiod fiscalperiod) {
			that.Post<UpdateResponse>("fiscalperiod/update.json", fiscalperiod.ToParameters()).EnsureSuccess();
		}

		public static void FiscalperiodDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("fiscalperiod/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static void FiscalperiodSwitch(this CashCtrlClient that, int id) {
			that.Post<ActionResponse>("fiscalperiod/switch.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).EnsureSuccess();
		}

		public static double FiscalperiodResult(this CashCtrlClient that, int id) {
			var data = that.GetString($"fiscalperiod/result", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			});
			return double.Parse(data, CultureInfo.InvariantCulture);
		}

		public static FiscalperiodDepreciation[] FiscalperiodDepreciations(this CashCtrlClient that) {
			return that.Get<ListResponse<FiscalperiodDepreciation>>("fiscalperiod/depreciations.json", null).Data;
		}

		public static void FiscalperiodBookDepreciations(this CashCtrlClient that, params int[] depreciation) {
			that.Post<ActionResponse>("fiscalperiod/bookdepreciations.json", new KeyValuePair<string, object>[] {
					new(nameof(depreciation), depreciation)
			}).EnsureSuccess();
		}

		public static FiscalperiodExchangeDiff[] FiscalperiodExchangediff(this CashCtrlClient that, DateTime? date) {
			return that.Get<ListResponse<FiscalperiodExchangeDiff>>("fiscalperiod/exchangediff.json", new KeyValuePair<string, object>[] {
					new(nameof(date), date.ToCashCtrlString(true))
			}).Data;
		}

		public static void FiscalperiodBookExchangediff(this CashCtrlClient that, DateTime? date, params FiscalperiodExchangeDiff[] exchangeDiff) {
			that.Post<ActionResponse>("fiscalperiod/bookexchangediff.json", new KeyValuePair<string, object>[] {
					new(nameof(date), date.ToCashCtrlString(true)),
					new(nameof(exchangeDiff), exchangeDiff)
			}).EnsureSuccess();
		}

		public static void FiscalperiodComplete(this CashCtrlClient that, int id) {
			that.Post<ActionResponse>("fiscalperiod/complete.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).EnsureSuccess();
		}

		public static void FiscalperiodReopen(this CashCtrlClient that, int id) {
			that.Post<ActionResponse>("fiscalperiod/reopen.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).EnsureSuccess();
		}
	}
}
