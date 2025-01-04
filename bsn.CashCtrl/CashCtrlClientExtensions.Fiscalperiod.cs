using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static void FiscalperiodBookDepreciations(this CashCtrlClient that, params int[] depreciation) {
			that.Post<ActionResponse>("fiscalperiod/bookdepreciations.json", new KeyValuePair<string, object>[] {
					new(nameof(depreciation), depreciation)
			}).EnsureSuccess();
		}

		public static async ValueTask FiscalperiodBookDepreciationsAsync(this CashCtrlClient that, params int[] depreciation) {
			var response = await that.PostAsync<ActionResponse>("fiscalperiod/bookdepreciations.json", new KeyValuePair<string, object>[] {
					new(nameof(depreciation), depreciation)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static void FiscalperiodBookExchangediff(this CashCtrlClient that, DateTime? date, params FiscalperiodExchangeDiff[] exchangeDiff) {
			that.Post<ActionResponse>("fiscalperiod/bookexchangediff.json", new KeyValuePair<string, object>[] {
					new(nameof(date), date.ToCashCtrlString(true)), new(nameof(exchangeDiff), exchangeDiff)
			}).EnsureSuccess();
		}

		public static async ValueTask FiscalperiodBookExchangediffAsync(this CashCtrlClient that, DateTime? date, params FiscalperiodExchangeDiff[] exchangeDiff) {
			var response = await that.PostAsync<ActionResponse>("fiscalperiod/bookexchangediff.json", new KeyValuePair<string, object>[] {
					new(nameof(date), date.ToCashCtrlString(true)), new(nameof(exchangeDiff), exchangeDiff)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static void FiscalperiodComplete(this CashCtrlClient that, int id) {
			that.Post<ActionResponse>("fiscalperiod/complete.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).EnsureSuccess();
		}

		public static async ValueTask FiscalperiodCompleteAsync(this CashCtrlClient that, int id) {
			var response = await that.PostAsync<ActionResponse>("fiscalperiod/complete.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static int FiscalperiodCreate(this CashCtrlClient that, Fiscalperiod fiscalperiod) {
			return that.Post<CreateResponse>("fiscalperiod/create.json", fiscalperiod.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> FiscalperiodCreateAsync(this CashCtrlClient that, Fiscalperiod fiscalperiod) {
			var response = await that.PostAsync<CreateResponse>("fiscalperiod/create.json", fiscalperiod.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void FiscalperiodDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("fiscalperiod/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask FiscalperiodDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("fiscalperiod/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static FiscalperiodDepreciation[] FiscalperiodDepreciations(this CashCtrlClient that) {
			return that.Get<ListResponse<FiscalperiodDepreciation>>("fiscalperiod/depreciations.json", null).Data;
		}

		public static async ValueTask<FiscalperiodDepreciation[]> FiscalperiodDepreciationsAsync(this CashCtrlClient that) {
			var response = await that.GetAsync<ListResponse<FiscalperiodDepreciation>>("fiscalperiod/depreciations.json", null).ConfigureAwait(false);
			return response.Data;
		}

		public static FiscalperiodExchangeDiff[] FiscalperiodExchangediff(this CashCtrlClient that, DateTime? date) {
			return that.Get<ListResponse<FiscalperiodExchangeDiff>>("fiscalperiod/exchangediff.json", new KeyValuePair<string, object>[] {
					new(nameof(date), date.ToCashCtrlString(true))
			}).Data;
		}

		public static async ValueTask<FiscalperiodExchangeDiff[]> FiscalperiodExchangediffAsync(this CashCtrlClient that, DateTime? date) {
			var response = await that.GetAsync<ListResponse<FiscalperiodExchangeDiff>>("fiscalperiod/exchangediff.json", new KeyValuePair<string, object>[] {
					new(nameof(date), date.ToCashCtrlString(true))
			}).ConfigureAwait(false);
			return response.Data;
		}

		public static Fiscalperiod[] FiscalperiodList(this CashCtrlClient that) {
			return that.Get<ListResponse<Fiscalperiod>>("fiscalperiod/list.json", null).Data;
		}

		public static async ValueTask<Fiscalperiod[]> FiscalperiodListAsync(this CashCtrlClient that) {
			var response = await that.GetAsync<ListResponse<Fiscalperiod>>("fiscalperiod/list.json", null).ConfigureAwait(false);
			return response.Data;
		}

		public static Fiscalperiod FiscalperiodRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<Fiscalperiod>>("fiscalperiod/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<Fiscalperiod> FiscalperiodReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<Fiscalperiod>>("fiscalperiod/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void FiscalperiodReopen(this CashCtrlClient that, int id) {
			that.Post<ActionResponse>("fiscalperiod/reopen.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).EnsureSuccess();
		}

		public static async ValueTask FiscalperiodReopenAsync(this CashCtrlClient that, int id) {
			var response = await that.PostAsync<ActionResponse>("fiscalperiod/reopen.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static double FiscalperiodResult(this CashCtrlClient that, int id) {
			var data = that.GetString("fiscalperiod/result", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			});
			return double.Parse(data, CultureInfo.InvariantCulture);
		}

		public static async ValueTask<double> FiscalperiodResultAsync(this CashCtrlClient that, int id) {
			var data = await that.GetStringAsync("fiscalperiod/result", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).ConfigureAwait(false);
			return double.Parse(data, CultureInfo.InvariantCulture);
		}

		public static void FiscalperiodSwitch(this CashCtrlClient that, int id) {
			that.Post<ActionResponse>("fiscalperiod/switch.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).EnsureSuccess();
		}

		public static async ValueTask FiscalperiodSwitchAsync(this CashCtrlClient that, int id) {
			var response = await that.PostAsync<ActionResponse>("fiscalperiod/switch.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static void FiscalperiodUpdate(this CashCtrlClient that, Fiscalperiod fiscalperiod) {
			that.Post<UpdateResponse>("fiscalperiod/update.json", fiscalperiod.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask FiscalperiodUpdateAsync(this CashCtrlClient that, Fiscalperiod fiscalperiod) {
			var response = await that.PostAsync<UpdateResponse>("fiscalperiod/update.json", fiscalperiod.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
