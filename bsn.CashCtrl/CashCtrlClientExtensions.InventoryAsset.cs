using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;
using bsn.CashCtrl.Response;
using bsn.HttpClientSync;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static void InventoryAssetAttachmentsUpdate(this CashCtrlClient that, int id, params int[] fileIds) {
			that.Post<ActionResponse>("inventory/asset/update_attachments.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new(nameof(fileIds), fileIds)
			}).EnsureSuccess();
		}

		public static async ValueTask InventoryAssetAttachmentsUpdateAsync(this CashCtrlClient that, int id, params int[] fileIds) {
			var response = await that.PostAsync<ActionResponse>("inventory/asset/update_attachments.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new(nameof(fileIds), fileIds)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static double InventoryAssetBalance(this CashCtrlClient that, int id, DateTime? date) {
			var data = that.GetString("inventory/asset/balance", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new(nameof(date), date)
			});
			return double.Parse(data, CultureInfo.InvariantCulture);
		}

		public static async ValueTask<double> InventoryAssetBalanceAsync(this CashCtrlClient that, int id, DateTime? date) {
			var data = await that.GetStringAsync("inventory/asset/balance", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new(nameof(date), date)
			}).ConfigureAwait(false);
			return double.Parse(data, CultureInfo.InvariantCulture);
		}

		public static void InventoryAssetCategorize(this CashCtrlClient that, int[] ids, int target) {
			that.Post<ActionResponse>("inventory/asset/categorize.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(target), target)
			}).EnsureSuccess();
		}

		public static async ValueTask InventoryAssetCategorizeAsync(this CashCtrlClient that, int[] ids, int target) {
			var response = await that.PostAsync<ActionResponse>("inventory/asset/categorize.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(target), target)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static int InventoryAssetCreate(this CashCtrlClient that, InventoryAsset inventoryAsset) {
			return that.Post<CreateResponse>("inventory/asset/create.json", inventoryAsset.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> InventoryAssetCreateAsync(this CashCtrlClient that, InventoryAsset inventoryAsset) {
			var response = await that.PostAsync<CreateResponse>("inventory/asset/create.json", inventoryAsset.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void InventoryAssetDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("inventory/asset/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask InventoryAssetDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("inventory/asset/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static InventoryAsset[] InventoryAssetList(this CashCtrlClient that, InventoryAssetQuery query = default) {
			return that.Get<ListResponse<InventoryAsset>>("inventory/asset/list.json", query?.ToParameters()).Data;
		}

		public static Stream InventoryAssetList(this CashCtrlClient that, CashCtrlDownloadFormat format, InventoryAssetQuery query = default) {
			return that.Get($"inventory/asset/list.{format.ToString().ToLowerInvariant()}", query?.ToParameters()).ReadAsStream();
		}

		public static async ValueTask<InventoryAsset[]> InventoryAssetListAsync(this CashCtrlClient that, InventoryAssetQuery query = default) {
			var response = await that.GetAsync<ListResponse<InventoryAsset>>("inventory/asset/list.json", query?.ToParameters()).ConfigureAwait(false);
			return response.Data;
		}

		public static async ValueTask<Stream> InventoryAssetListAsync(this CashCtrlClient that, CashCtrlDownloadFormat format, InventoryAssetQuery query = default) {
			var content = await that.GetAsync($"inventory/asset/list.{format.ToString().ToLowerInvariant()}", query?.ToParameters()).ConfigureAwait(false);
			return await content.ReadAsStreamAsync().ConfigureAwait(false);
		}

		public static InventoryAsset InventoryAssetRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<InventoryAsset>>("inventory/asset/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<InventoryAsset> InventoryAssetReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<InventoryAsset>>("inventory/asset/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void InventoryAssetUpdate(this CashCtrlClient that, InventoryAsset inventoryAsset) {
			that.Post<UpdateResponse>("inventory/asset/update.json", inventoryAsset.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask InventoryAssetUpdateAsync(this CashCtrlClient that, InventoryAsset inventoryAsset) {
			var response = await that.PostAsync<UpdateResponse>("inventory/asset/update.json", inventoryAsset.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
