using System;
using System.Collections.Generic;
using System.Globalization;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static InventoryUnit InventoryUnitRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<InventoryUnit>>("inventory/unit/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static InventoryUnit[] InventoryUnitList(this CashCtrlClient that) {
			return that.Get<ListResponse<InventoryUnit>>("inventory/unit/list.json", null).Data;
		}

		public static int InventoryUnitCreate(this CashCtrlClient that, InventoryUnit inventoryUnit) {
			return that.Post<CreateResponse>("inventory/unit/create.json", inventoryUnit.ToParameters()).GetInsertIdOrThrow();
		}

		public static void InventoryUnitUpdate(this CashCtrlClient that, InventoryUnit inventoryUnit) {
			that.Post<UpdateResponse>("inventory/unit/update.json", inventoryUnit.ToParameters()).EnsureSuccess();
		}

		public static void InventoryUnitDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("inventory/unit/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static double InventoryUnitExchangerate(this CashCtrlClient that, string from, string to, DateTime? date) {
			var data = that.GetString($"inventory/unit/exchangerate", new KeyValuePair<string, object>[] {
					new(nameof(from), from),
					new(nameof(to), to),
					new(nameof(date), date)
			});
			return double.Parse(data, CultureInfo.InvariantCulture);
		}
	}
}
