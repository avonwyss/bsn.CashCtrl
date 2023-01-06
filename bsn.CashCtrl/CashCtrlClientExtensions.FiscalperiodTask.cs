using System.Collections.Generic;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static FiscalperiodTask[] FiscalperiodTaskList(this CashCtrlClient that) {
			return that.Get<ListResponse<FiscalperiodTask>>("fiscalperiod/task/list.json", null).Data;
		}

		public static int FiscalperiodTaskCreate(this CashCtrlClient that, FiscalperiodTask fiscalperiodTask) {
			return that.Post<CreateResponse>("fiscalperiod/task/create.json", fiscalperiodTask.ToParameters()).GetInsertIdOrThrow();
		}

		public static void FiscalperiodTaskDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("fiscalperiod/task/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}
	}
}
