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
		public static void AccountCostCenterAttachmentsUpdate(this CashCtrlClient that, int id, params int[] fileIds) {
			that.Post<ActionResponse>("account/costcenter/update_attachments.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new(nameof(fileIds), fileIds)
			}).EnsureSuccess();
		}

		public static async ValueTask AccountCostCenterAttachmentsUpdateAsync(this CashCtrlClient that, int id, params int[] fileIds) {
			var response = await that.PostAsync<ActionResponse>("account/costcenter/update_attachments.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new(nameof(fileIds), fileIds)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static double AccountCostCenterBalance(this CashCtrlClient that, int id, DateTime? date) {
			var data = that.GetString("account/costcenter/balance", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new(nameof(date), date)
			});
			return double.Parse(data, CultureInfo.InvariantCulture);
		}

		public static async ValueTask<double> AccountCostCenterBalanceAsync(this CashCtrlClient that, int id, DateTime? date) {
			var data = await that.GetStringAsync("account/costcenter/balance", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new(nameof(date), date)
			}).ConfigureAwait(false);
			return double.Parse(data, CultureInfo.InvariantCulture);
		}

		public static void AccountCostCenterCategorize(this CashCtrlClient that, int[] ids, int target) {
			that.Post<ActionResponse>("account/costcenter/categorize.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(target), target)
			}).EnsureSuccess();
		}

		public static async ValueTask AccountCostCenterCategorizeAsync(this CashCtrlClient that, int[] ids, int target) {
			var response = await that.PostAsync<ActionResponse>("account/costcenter/categorize.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(target), target)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static int AccountCostCenterCreate(this CashCtrlClient that, AccountCostCenter account) {
			return that.Post<CreateResponse>("account/costcenter/create.json", account.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> AccountCostCenterCreateAsync(this CashCtrlClient that, AccountCostCenter account) {
			var response = await that.PostAsync<CreateResponse>("account/costcenter/create.json", account.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void AccountCostCenterDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("account/costcenter/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask AccountCostCenterDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("account/costcenter/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static AccountCostCenter[] AccountCostCenterList(this CashCtrlClient that, AccountCostCenterQuery query = default) {
			return that.Get<ListResponse<AccountCostCenter>>("account/costcenter/list.json", query?.ToParameters()).Data;
		}

		public static Stream AccountCostCenterList(this CashCtrlClient that, CashCtrlDownloadFormat format, AccountCostCenterQuery query = default) {
			return that.Get($"account/costcenter/list.{format.ToString().ToLowerInvariant()}", query?.ToParameters()).ReadAsStream();
		}

		public static async ValueTask<AccountCostCenter[]> AccountCostCenterListAsync(this CashCtrlClient that, AccountCostCenterQuery query = default) {
			var response = await that.GetAsync<ListResponse<AccountCostCenter>>("account/costcenter/list.json", query?.ToParameters()).ConfigureAwait(false);
			return response.Data;
		}

		public static async ValueTask<Stream> AccountCostCenterListAsync(this CashCtrlClient that, CashCtrlDownloadFormat format, AccountCostCenterQuery query = default) {
			var content = await that.GetAsync($"account/costcenter/list.{format.ToString().ToLowerInvariant()}", query?.ToParameters()).ConfigureAwait(false);
			return await content.ReadAsStreamAsync().ConfigureAwait(false);
		}

		public static AccountCostCenter AccountCostCenterRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<AccountCostCenter>>("account/costcenter/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<AccountCostCenter> AccountCostCenterReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<AccountCostCenter>>("account/costcenter/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void AccountCostCenterUpdate(this CashCtrlClient that, AccountCostCenter account) {
			that.Post<UpdateResponse>("account/costcenter/update.json", account.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask AccountCostCenterUpdateAsync(this CashCtrlClient that, AccountCostCenter account) {
			var response = await that.PostAsync<UpdateResponse>("account/costcenter/update.json", account.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
