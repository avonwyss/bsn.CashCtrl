using System.Collections.Generic;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int FiscalperiodTaskCreate(this CashCtrlClient that, FiscalperiodTask fiscalperiodTask) {
			return that.Post<CreateResponse>("fiscalperiod/task/create.json", fiscalperiodTask.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> FiscalperiodTaskCreateAsync(this CashCtrlClient that, FiscalperiodTask fiscalperiodTask) {
			var response = await that.PostAsync<CreateResponse>("fiscalperiod/task/create.json", fiscalperiodTask.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void FiscalperiodTaskDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("fiscalperiod/task/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask FiscalperiodTaskDeleteAsync(this CashCtrlClient that, params int[] ids) {
			await that.PostAsync<DeleteResponse>("fiscalperiod/task/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
		}

		public static FiscalperiodTask[] FiscalperiodTaskList(this CashCtrlClient that) {
			return that.Get<ListResponse<FiscalperiodTask>>("fiscalperiod/task/list.json", null).Data;
		}

		public static async ValueTask<FiscalperiodTask[]> FiscalperiodTaskListAsync(this CashCtrlClient that) {
			var response = await that.GetAsync<ListResponse<FiscalperiodTask>>("fiscalperiod/task/list.json", null).ConfigureAwait(false);
			return response.Data;
		}
	}
}
