using System;
using System.Collections.Generic;
using System.IO;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Http;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static ReportSet ReportSetRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<ReportSet>>("report/set/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static int ReportSetCreate(this CashCtrlClient that, ReportSet reportSet) {
			return that.Post<CreateResponse>("report/set/create.json", reportSet.ToParameters()).GetInsertIdOrThrow();
		}

		public static void ReportSetUpdate(this CashCtrlClient that, ReportSet reportSet) {
			that.Post<UpdateResponse>("report/set/update.json", reportSet.ToParameters()).EnsureSuccess();
		}

		public static void ReportSetDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("report/set/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static void ReportSetReorder(this CashCtrlClient that, int[] ids, int target, bool? before = default) {
			that.Post<ActionResponse>("report/set/reorder.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids),
					new(nameof(target), target),
					new(nameof(before), before)
			}).EnsureSuccess();
		}

		public static ReportMeta ReportSetMeta(this CashCtrlClient that, int setId, int? fiscalPeriodId = default, DateTime? startDate = default, DateTime? endDate = default, string language = default, string sort = default) {
			return that.Get<ReadResponse<ReportMeta>>("report/set/meta.json", new KeyValuePair<string, object>[] {
					new(nameof(setId), setId),
					new(nameof(fiscalPeriodId), fiscalPeriodId),
					new(nameof(startDate), startDate.ToCashCtrlString(true)),
					new(nameof(endDate), endDate.ToCashCtrlString(true)),
					new(nameof(language), language),
					new(nameof(sort), sort)
			}).GetDataOrThrow();
		}

		public static Stream ReportSetDownload(this CashCtrlClient that, CashCtrlDownloadFormat format, int setId, int? fiscalPeriodId = default, DateTime? startDate = default, DateTime? endDate = default, string language = default, string sort = default) {
			return that.Get($"report/set/download.{format.ToString().ToLowerInvariant()}", new KeyValuePair<string, object>[] {
					new(nameof(setId), setId),
					new(nameof(fiscalPeriodId), fiscalPeriodId),
					new(nameof(startDate), startDate.ToCashCtrlString(true)),
					new(nameof(endDate), endDate.ToCashCtrlString(true)),
					new(nameof(language), language),
					new(nameof(sort), sort)
			}).ReadAsStream();
		}

		public static Stream ReportSetDownloadAnnualReport(this CashCtrlClient that, int? fiscalPeriodId = default) {
			return that.Get("report/set/download_annualreport.pdf", new KeyValuePair<string, object>[] {
					new(nameof(fiscalPeriodId), fiscalPeriodId)
			}).ReadAsStream();
		}
	}
}
