using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;
using bsn.HttpClientSync;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int ReportSetCreate(this CashCtrlClient that, ReportSet reportSet) {
			return that.Post<CreateResponse>("report/set/create.json", reportSet.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> ReportSetCreateAsync(this CashCtrlClient that, ReportSet reportSet) {
			var response = await that.PostAsync<CreateResponse>("report/set/create.json", reportSet.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void ReportSetDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("report/set/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask ReportSetDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("report/set/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static Stream ReportSetDownload(this CashCtrlClient that, CashCtrlDownloadFormat format, int setId, int? fiscalPeriodId = default, DateTime? startDate = default, DateTime? endDate = default, string language = default, string sort = default) {
			return that.Get($"report/set/download.{format.ToString().ToLowerInvariant()}", new KeyValuePair<string, object>[] {
					new(nameof(setId), setId), new(nameof(fiscalPeriodId), fiscalPeriodId), new(nameof(startDate), startDate.ToCashCtrlString(true)), new(nameof(endDate), endDate.ToCashCtrlString(true)), new(nameof(language), language), new(nameof(sort), sort)
			}).ReadAsStream();
		}

		public static Stream ReportSetDownloadAnnualReport(this CashCtrlClient that, int? fiscalPeriodId = default) {
			return that.Get("report/set/download_annualreport.pdf", new KeyValuePair<string, object>[] {
					new(nameof(fiscalPeriodId), fiscalPeriodId)
			}).ReadAsStream();
		}

		public static async ValueTask<Stream> ReportSetDownloadAnnualReportAsync(this CashCtrlClient that, int? fiscalPeriodId = default) {
			var content = await that.GetAsync("report/set/download_annualreport.pdf", new KeyValuePair<string, object>[] {
					new(nameof(fiscalPeriodId), fiscalPeriodId)
			}).ConfigureAwait(false);
			return await content.ReadAsStreamAsync().ConfigureAwait(false);
		}

		public static async ValueTask<Stream> ReportSetDownloadAsync(this CashCtrlClient that, CashCtrlDownloadFormat format, int setId, int? fiscalPeriodId = default, DateTime? startDate = default, DateTime? endDate = default, string language = default, string sort = default) {
			var content = await that.GetAsync($"report/set/download.{format.ToString().ToLowerInvariant()}", new KeyValuePair<string, object>[] {
					new(nameof(setId), setId), new(nameof(fiscalPeriodId), fiscalPeriodId), new(nameof(startDate), startDate.ToCashCtrlString(true)), new(nameof(endDate), endDate.ToCashCtrlString(true)), new(nameof(language), language), new(nameof(sort), sort)
			}).ConfigureAwait(false);
			return await content.ReadAsStreamAsync().ConfigureAwait(false);
		}

		public static ReportMeta ReportSetMeta(this CashCtrlClient that, int setId, int? fiscalPeriodId = default, DateTime? startDate = default, DateTime? endDate = default, string language = default, string sort = default) {
			return that.Get<ReadResponse<ReportMeta>>("report/set/meta.json", new KeyValuePair<string, object>[] {
					new(nameof(setId), setId), new(nameof(fiscalPeriodId), fiscalPeriodId), new(nameof(startDate), startDate.ToCashCtrlString(true)), new(nameof(endDate), endDate.ToCashCtrlString(true)), new(nameof(language), language), new(nameof(sort), sort)
			}).GetDataOrThrow();
		}

		public static async ValueTask<ReportMeta> ReportSetMetaAsync(this CashCtrlClient that, int setId, int? fiscalPeriodId = default, DateTime? startDate = default, DateTime? endDate = default, string language = default, string sort = default) {
			var response = await that.GetAsync<ReadResponse<ReportMeta>>("report/set/meta.json", new KeyValuePair<string, object>[] {
					new(nameof(setId), setId), new(nameof(fiscalPeriodId), fiscalPeriodId), new(nameof(startDate), startDate.ToCashCtrlString(true)), new(nameof(endDate), endDate.ToCashCtrlString(true)), new(nameof(language), language), new(nameof(sort), sort)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static ReportSet ReportSetRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<ReportSet>>("report/set/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<ReportSet> ReportSetReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<ReportSet>>("report/set/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void ReportSetReorder(this CashCtrlClient that, int[] ids, int target, bool? before = default) {
			that.Post<ActionResponse>("report/set/reorder.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(target), target), new(nameof(before), before)
			}).EnsureSuccess();
		}

		public static async ValueTask ReportSetReorderAsync(this CashCtrlClient that, int[] ids, int target, bool? before = default) {
			var response = await that.PostAsync<ActionResponse>("report/set/reorder.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(target), target), new(nameof(before), before)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static void ReportSetUpdate(this CashCtrlClient that, ReportSet reportSet) {
			that.Post<UpdateResponse>("report/set/update.json", reportSet.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask ReportSetUpdateAsync(this CashCtrlClient that, ReportSet reportSet) {
			var response = await that.PostAsync<UpdateResponse>("report/set/update.json", reportSet.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
