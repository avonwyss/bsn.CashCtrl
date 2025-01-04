using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int InventoryUnitCreate(this CashCtrlClient that, InventoryUnit inventoryUnit) {
			return that.Post<CreateResponse>("inventory/unit/create.json", inventoryUnit.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> InventoryUnitCreateAsync(this CashCtrlClient that, InventoryUnit inventoryUnit) {
			var response = await that.PostAsync<CreateResponse>("inventory/unit/create.json", inventoryUnit.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void InventoryUnitDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("inventory/unit/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask InventoryUnitDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("inventory/unit/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static double InventoryUnitExchangerate(this CashCtrlClient that, string from, string to, DateTime? date) {
			var data = that.GetString("inventory/unit/exchangerate", new KeyValuePair<string, object>[] {
					new(nameof(from), from), new(nameof(to), to), new(nameof(date), date)
			});
			return double.Parse(data, CultureInfo.InvariantCulture);
		}

		public static async ValueTask<double> InventoryUnitExchangerateAsync(this CashCtrlClient that, string from, string to, DateTime? date) {
			var data = await that.GetStringAsync("inventory/unit/exchangerate", new KeyValuePair<string, object>[] {
					new(nameof(from), from), new(nameof(to), to), new(nameof(date), date)
			}).ConfigureAwait(false);
			return double.Parse(data, CultureInfo.InvariantCulture);
		}

		public static InventoryUnit[] InventoryUnitList(this CashCtrlClient that) {
			return that.Get<ListResponse<InventoryUnit>>("inventory/unit/list.json", null).Data;
		}

		public static async ValueTask<InventoryUnit[]> InventoryUnitListAsync(this CashCtrlClient that) {
			var response = await that.GetAsync<ListResponse<InventoryUnit>>("inventory/unit/list.json", null).ConfigureAwait(false);
			return response.Data;
		}

		public static InventoryUnit InventoryUnitRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<InventoryUnit>>("inventory/unit/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<InventoryUnit> InventoryUnitReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<InventoryUnit>>("inventory/unit/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void InventoryUnitUpdate(this CashCtrlClient that, InventoryUnit inventoryUnit) {
			that.Post<UpdateResponse>("inventory/unit/update.json", inventoryUnit.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask InventoryUnitUpdateAsync(this CashCtrlClient that, InventoryUnit inventoryUnit) {
			var response = await that.PostAsync<UpdateResponse>("inventory/unit/update.json", inventoryUnit.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
