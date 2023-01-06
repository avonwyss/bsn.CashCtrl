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
		public static AccountCostCenter AccountCostCenterRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<AccountCostCenter>>("account/costcenter/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static AccountCostCenter[] AccountCostCenterList(this CashCtrlClient that, AccountQuery query = default) {
			return that.Get<ListResponse<AccountCostCenter>>("account/costcenter/list.json", query?.ToParameters()).Data;
		}

		public static Stream AccountCostCenterList(this CashCtrlClient that, CashCtrlDownloadFormat format, AccountQuery query = default) {
			return that.Get($"account/costcenter/list.{format.ToString().ToLowerInvariant()}", query?.ToParameters()).ReadAsStream();
		}

		public static double AccountCostCenterBalance(this CashCtrlClient that, int id, DateTime? date) {
			var data = that.GetString($"account/costcenter/balance", new KeyValuePair<string, object>[] {
					new(nameof(id), id),
					new(nameof(date), date)
			});
			return double.Parse(data, CultureInfo.InvariantCulture);
		}

		public static int AccountCostCenterCreate(this CashCtrlClient that, AccountCostCenter account) {
			return that.Post<CreateResponse>("account/costcenter/create.json", account.ToParameters()).GetInsertIdOrThrow();
		}

		public static void AccountCostCenterUpdate(this CashCtrlClient that, AccountCostCenter account) {
			that.Post<UpdateResponse>("account/costcenter/update.json", account.ToParameters()).EnsureSuccess();
		}

		public static void AccountCostCenterDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("account/costcenter/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static void AccountCostCenterCategorize(this CashCtrlClient that, int[] ids, int target) {
			that.Post<ActionResponse>("account/costcenter/categorize.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids),
					new(nameof(target), target)
			}).EnsureSuccess();
		}

		public static void AccountCostCenterAttachmentsUpdate(this CashCtrlClient that, int id, params int[] fileIds) {
			that.Post<ActionResponse>("account/costcenter/update_attachments.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id),
					new(nameof(fileIds), fileIds)
			}).EnsureSuccess();
		}
	}
}
