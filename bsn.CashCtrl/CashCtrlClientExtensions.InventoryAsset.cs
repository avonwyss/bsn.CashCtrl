using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Http;
using bsn.CashCtrl.Query;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static InventoryAsset InventoryAssetRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<InventoryAsset>>("inventory/asset/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static InventoryAsset[] InventoryAssetList(this CashCtrlClient that, InventoryAssetQuery query = default) {
			return that.Get<ListResponse<InventoryAsset>>("inventory/asset/list.json", query?.ToParameters()).Data;
		}

		public static Stream InventoryAssetList(this CashCtrlClient that, CashCtrlDownloadFormat format, InventoryAssetQuery query = default) {
			return that.Get($"inventory/asset/list.{format.ToString().ToLowerInvariant()}", query?.ToParameters()).ReadAsStream();
		}

		public static double InventoryAssetBalance(this CashCtrlClient that, int id, DateTime? date) {
			var data = that.GetString($"inventory/asset/balance", new KeyValuePair<string, object>[] {
					new(nameof(id), id),
					new(nameof(date), date)
			});
			return double.Parse(data, CultureInfo.InvariantCulture);
		}

		public static int InventoryAssetCreate(this CashCtrlClient that, InventoryAsset inventoryAsset) {
			return that.Post<CreateResponse>("inventory/asset/create.json", inventoryAsset.ToParameters()).GetInsertIdOrThrow();
		}

		public static void InventoryAssetUpdate(this CashCtrlClient that, InventoryAsset inventoryAsset) {
			that.Post<UpdateResponse>("inventory/asset/update.json", inventoryAsset.ToParameters()).EnsureSuccess();
		}

		public static void InventoryAssetDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("inventory/asset/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static void InventoryAssetCategorize(this CashCtrlClient that, int[] ids, int target) {
			that.Post<ActionResponse>("inventory/asset/categorize.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids),
					new(nameof(target), target)
			}).EnsureSuccess();
		}

		public static void InventoryAssetAttachmentsUpdate(this CashCtrlClient that, int id, params int[] fileIds) {
			that.Post<ActionResponse>("inventory/asset/update_attachments.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id),
					new(nameof(fileIds), fileIds)
			}).EnsureSuccess();
		}
	}
}
