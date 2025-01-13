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
		public static void AccountAttachmentsUpdate(this CashCtrlClient that, int id, params int[] fileIds) {
			that.Post<ActionResponse>("account/update_attachments.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new("attachments", CashCtrlAttachment.Create(fileIds))
			}).EnsureSuccess();
		}

		public static async ValueTask AccountAttachmentsUpdateAsync(this CashCtrlClient that, int id, params int[] fileIds) {
			var response = await that.PostAsync<ActionResponse>("account/update_attachments.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new("attachments", CashCtrlAttachment.Create(fileIds))
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static double AccountBalance(this CashCtrlClient that, int id, DateTime? date) {
			var data = that.GetString("account/balance", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new(nameof(date), date)
			});
			return double.Parse(data, CultureInfo.InvariantCulture);
		}

		public static async ValueTask<double> AccountBalanceAsync(this CashCtrlClient that, int id, DateTime? date) {
			var data = await that.GetStringAsync("account/balance", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new(nameof(date), date)
			}).ConfigureAwait(false);
			return double.Parse(data, CultureInfo.InvariantCulture);
		}

		public static void AccountCategorize(this CashCtrlClient that, int[] ids, int target) {
			that.Post<ActionResponse>("account/categorize.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(target), target)
			}).EnsureSuccess();
		}

		public static async ValueTask AccountCategorizeAsync(this CashCtrlClient that, int[] ids, int target) {
			var response = await that.PostAsync<ActionResponse>("account/categorize.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(target), target)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static int AccountCreate(this CashCtrlClient that, Account account) {
			return that.Post<CreateResponse>("account/create.json", account.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> AccountCreateAsync(this CashCtrlClient that, Account account) {
			var response = await that.PostAsync<CreateResponse>("account/create.json", account.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void AccountDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("account/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask AccountDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("account/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static Account[] AccountList(this CashCtrlClient that, AccountQuery query = default) {
			return that.Get<ListResponse<Account>>("account/list.json", query?.ToParameters()).Data;
		}

		public static Stream AccountList(this CashCtrlClient that, CashCtrlDownloadFormat format, AccountQuery query = default) {
			return that.Get($"account/list.{format.ToString().ToLowerInvariant()}", query?.ToParameters()).ReadAsStream();
		}

		public static async ValueTask<Account[]> AccountListAsync(this CashCtrlClient that, AccountQuery query = default) {
			var response = await that.GetAsync<ListResponse<Account>>("account/list.json", query?.ToParameters()).ConfigureAwait(false);
			return response.Data;
		}

		public static async ValueTask<Stream> AccountListAsync(this CashCtrlClient that, CashCtrlDownloadFormat format, AccountQuery query = default) {
			var content = await that.GetAsync($"account/list.{format.ToString().ToLowerInvariant()}", query?.ToParameters()).ConfigureAwait(false);
			return await content.ReadAsStreamAsync().ConfigureAwait(false);
		}

		public static Account AccountRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<Account>>("account/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<Account> AccountReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<Account>>("account/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void AccountUpdate(this CashCtrlClient that, Account account) {
			that.Post<UpdateResponse>("account/update.json", account.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask AccountUpdateAsync(this CashCtrlClient that, Account account) {
			var response = await that.PostAsync<UpdateResponse>("account/update.json", account.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
