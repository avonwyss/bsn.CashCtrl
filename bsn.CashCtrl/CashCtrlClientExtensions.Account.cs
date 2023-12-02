using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;
using bsn.CashCtrl.Response;
using bsn.HttpClientSync;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static Account AccountRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<Account>>("account/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static Account[] AccountList(this CashCtrlClient that, AccountQuery query = default) {
			return that.Get<ListResponse<Account>>("account/list.json", query?.ToParameters()).Data;
		}

		public static Stream AccountList(this CashCtrlClient that, CashCtrlDownloadFormat format, AccountQuery query = default) {
			return that.Get($"account/list.{format.ToString().ToLowerInvariant()}", query?.ToParameters()).ReadAsStream();
		}

		public static double AccountBalance(this CashCtrlClient that, int id, DateTime? date) {
			var data = that.GetString($"account/balance", new KeyValuePair<string, object>[] {
					new(nameof(id), id),
					new(nameof(date), date)
			});
			return double.Parse(data, CultureInfo.InvariantCulture);
		}

		public static int AccountCreate(this CashCtrlClient that, Account account) {
			return that.Post<CreateResponse>("account/create.json", account.ToParameters()).GetInsertIdOrThrow();
		}

		public static void AccountUpdate(this CashCtrlClient that, Account account) {
			that.Post<UpdateResponse>("account/update.json", account.ToParameters()).EnsureSuccess();
		}

		public static void AccountDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("account/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static void AccountCategorize(this CashCtrlClient that, int[] ids, int target) {
			that.Post<ActionResponse>("account/categorize.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids),
					new(nameof(target), target)
			}).EnsureSuccess();
		}

		public static void AccountAttachmentsUpdate(this CashCtrlClient that, int id, params int[] fileIds) {
			that.Post<ActionResponse>("account/update_attachments.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id),
					new(nameof(fileIds), fileIds)
			}).EnsureSuccess();
		}
	}
}
