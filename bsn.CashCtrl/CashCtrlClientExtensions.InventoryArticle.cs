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
		public static void InventoryArticleAttachmentsUpdate(this CashCtrlClient that, int id, params int[] fileIds) {
			that.Post<ActionResponse>("inventory/article/update_attachments.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new("attachments", CashCtrlAttachment.Create(fileIds))
			}).EnsureSuccess();
		}

		public static async ValueTask InventoryArticleAttachmentsUpdateAsync(this CashCtrlClient that, int id, params int[] fileIds) {
			var response = await that.PostAsync<ActionResponse>("inventory/article/update_attachments.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new("attachments", CashCtrlAttachment.Create(fileIds))
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static double InventoryArticleBalance(this CashCtrlClient that, int id, DateTime? date) {
			var data = that.GetString("inventory/article/balance", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new(nameof(date), date)
			});
			return double.Parse(data, CultureInfo.InvariantCulture);
		}

		public static async ValueTask<double> InventoryArticleBalanceAsync(this CashCtrlClient that, int id, DateTime? date) {
			var data = await that.GetStringAsync("inventory/article/balance", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new(nameof(date), date)
			}).ConfigureAwait(false);
			return double.Parse(data, CultureInfo.InvariantCulture);
		}

		public static void InventoryArticleCategorize(this CashCtrlClient that, int[] ids, int target) {
			that.Post<ActionResponse>("inventory/article/categorize.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(target), target)
			}).EnsureSuccess();
		}

		public static async ValueTask InventoryArticleCategorizeAsync(this CashCtrlClient that, int[] ids, int target) {
			var response = await that.PostAsync<ActionResponse>("inventory/article/categorize.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(target), target)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static int InventoryArticleCreate(this CashCtrlClient that, InventoryArticle inventoryArticle) {
			return that.Post<CreateResponse>("inventory/article/create.json", inventoryArticle.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> InventoryArticleCreateAsync(this CashCtrlClient that, InventoryArticle inventoryArticle) {
			var response = await that.PostAsync<CreateResponse>("inventory/article/create.json", inventoryArticle.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void InventoryArticleDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("inventory/article/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask InventoryArticleDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("inventory/article/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static InventoryArticle[] InventoryArticleList(this CashCtrlClient that, InventoryArticleQuery query = default) {
			return that.Get<ListResponse<InventoryArticle>>("inventory/article/list.json", query?.ToParameters()).Data;
		}

		public static Stream InventoryArticleList(this CashCtrlClient that, CashCtrlDownloadFormat format, InventoryArticleQuery query = default) {
			return that.Get($"inventory/article/list.{format.ToString().ToLowerInvariant()}", query?.ToParameters()).ReadAsStream();
		}

		public static async ValueTask<InventoryArticle[]> InventoryArticleListAsync(this CashCtrlClient that, InventoryArticleQuery query = default) {
			var response = await that.GetAsync<ListResponse<InventoryArticle>>("inventory/article/list.json", query?.ToParameters()).ConfigureAwait(false);
			return response.Data;
		}

		public static async ValueTask<Stream> InventoryArticleListAsync(this CashCtrlClient that, CashCtrlDownloadFormat format, InventoryArticleQuery query = default) {
			var content = await that.GetAsync($"inventory/article/list.{format.ToString().ToLowerInvariant()}", query?.ToParameters()).ConfigureAwait(false);
			return await content.ReadAsStreamAsync().ConfigureAwait(false);
		}

		public static InventoryArticle InventoryArticleRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<InventoryArticle>>("inventory/article/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<InventoryArticle> InventoryArticleReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<InventoryArticle>>("inventory/article/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void InventoryArticleUpdate(this CashCtrlClient that, InventoryArticle inventoryArticle) {
			that.Post<UpdateResponse>("inventory/article/update.json", inventoryArticle.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask InventoryArticleUpdateAsync(this CashCtrlClient that, InventoryArticle inventoryArticle) {
			var response = await that.PostAsync<UpdateResponse>("inventory/article/update.json", inventoryArticle.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
