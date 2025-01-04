using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;
using bsn.HttpClientSync;

using Newtonsoft.Json.Linq;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int ReportElementCreate(this CashCtrlClient that, ReportElement reportElement) {
			return that.Post<CreateResponse>("report/element/create.json", reportElement.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> ReportElementCreateAsync(this CashCtrlClient that, ReportElement reportElement) {
			var response = await that.PostAsync<CreateResponse>("report/element/create.json", reportElement.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static ListResponse<JObject> ReportElementData(this CashCtrlClient that, int elementId, int? fiscalPeriodId = default, DateTime? startDate = default, DateTime? endDate = default, string language = default, string sort = default) {
			return that.Get<ListResponse<JObject>>("report/element/data.json", new KeyValuePair<string, object>[] {
					new(nameof(elementId), elementId), new(nameof(fiscalPeriodId), fiscalPeriodId), new(nameof(startDate), startDate.ToCashCtrlString(true)), new(nameof(endDate), endDate.ToCashCtrlString(true)), new(nameof(language), language), new(nameof(sort), sort)
			});
		}

		public static async ValueTask<ListResponse<JObject>> ReportElementDataAsync(this CashCtrlClient that, int elementId, int? fiscalPeriodId = default, DateTime? startDate = default, DateTime? endDate = default, string language = default, string sort = default) {
			var response = await that.GetAsync<ListResponse<JObject>>("report/element/data.json", new KeyValuePair<string, object>[] {
					new(nameof(elementId), elementId), new(nameof(fiscalPeriodId), fiscalPeriodId), new(nameof(startDate), startDate.ToCashCtrlString(true)), new(nameof(endDate), endDate.ToCashCtrlString(true)), new(nameof(language), language), new(nameof(sort), sort)
			}).ConfigureAwait(false);
			return response;
		}

		public static void ReportElementDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("report/element/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask ReportElementDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("report/element/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static Stream ReportElementDownload(this CashCtrlClient that, CashCtrlDownloadFormat format, int elementId, int? fiscalPeriodId = default, DateTime? startDate = default, DateTime? endDate = default, string language = default, string sort = default) {
			return that.Get($"report/element/download.{format.ToString().ToLowerInvariant()}", new KeyValuePair<string, object>[] {
					new(nameof(elementId), elementId), new(nameof(fiscalPeriodId), fiscalPeriodId), new(nameof(startDate), startDate.ToCashCtrlString(true)), new(nameof(endDate), endDate.ToCashCtrlString(true)), new(nameof(language), language), new(nameof(sort), sort)
			}).ReadAsStream();
		}

		public static async ValueTask<Stream> ReportElementDownloadAsync(this CashCtrlClient that, CashCtrlDownloadFormat format, int elementId, int? fiscalPeriodId = default, DateTime? startDate = default, DateTime? endDate = default, string language = default, string sort = default) {
			var content = await that.GetAsync($"report/element/download.{format.ToString().ToLowerInvariant()}", new KeyValuePair<string, object>[] {
					new(nameof(elementId), elementId), new(nameof(fiscalPeriodId), fiscalPeriodId), new(nameof(startDate), startDate.ToCashCtrlString(true)), new(nameof(endDate), endDate.ToCashCtrlString(true)), new(nameof(language), language), new(nameof(sort), sort)
			}).ConfigureAwait(false);
			return await content.ReadAsStreamAsync().ConfigureAwait(false);
		}

		public static string ReportElementHtml(this CashCtrlClient that, int elementId, int? fiscalPeriodId = default, DateTime? startDate = default, DateTime? endDate = default, string language = default, string sort = default) {
			return that.GetString("report/element/data.json", new KeyValuePair<string, object>[] {
					new(nameof(elementId), elementId), new(nameof(fiscalPeriodId), fiscalPeriodId), new(nameof(startDate), startDate.ToCashCtrlString(true)), new(nameof(endDate), endDate.ToCashCtrlString(true)), new(nameof(language), language), new(nameof(sort), sort)
			});
		}

		public static async ValueTask<string> ReportElementHtmlAsync(this CashCtrlClient that, int elementId, int? fiscalPeriodId = default, DateTime? startDate = default, DateTime? endDate = default, string language = default, string sort = default) {
			var response = await that.GetStringAsync("report/element/data.json", new KeyValuePair<string, object>[] {
					new(nameof(elementId), elementId), new(nameof(fiscalPeriodId), fiscalPeriodId), new(nameof(startDate), startDate.ToCashCtrlString(true)), new(nameof(endDate), endDate.ToCashCtrlString(true)), new(nameof(language), language), new(nameof(sort), sort)
			}).ConfigureAwait(false);
			return response;
		}

		public static ReportMeta ReportElementMeta(this CashCtrlClient that, int elementId, int? fiscalPeriodId = default, DateTime? startDate = default, DateTime? endDate = default, string language = default, string sort = default) {
			return that.Get<ReadResponse<ReportMeta>>("report/element/meta.json", new KeyValuePair<string, object>[] {
					new(nameof(elementId), elementId), new(nameof(fiscalPeriodId), fiscalPeriodId), new(nameof(startDate), startDate.ToCashCtrlString(true)), new(nameof(endDate), endDate.ToCashCtrlString(true)), new(nameof(language), language), new(nameof(sort), sort)
			}).GetDataOrThrow();
		}

		public static async ValueTask<ReportMeta> ReportElementMetaAsync(this CashCtrlClient that, int elementId, int? fiscalPeriodId = default, DateTime? startDate = default, DateTime? endDate = default, string language = default, string sort = default) {
			var response = await that.GetAsync<ReadResponse<ReportMeta>>("report/element/meta.json", new KeyValuePair<string, object>[] {
					new(nameof(elementId), elementId), new(nameof(fiscalPeriodId), fiscalPeriodId), new(nameof(startDate), startDate.ToCashCtrlString(true)), new(nameof(endDate), endDate.ToCashCtrlString(true)), new(nameof(language), language), new(nameof(sort), sort)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static ReportElement ReportElementRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<ReportElement>>("report/element/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<ReportElement> ReportElementReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<ReportElement>>("report/element/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void ReportElementReorder(this CashCtrlClient that, int[] ids, int target, bool? before = default) {
			that.Post<ActionResponse>("report/element/reorder.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(target), target), new(nameof(before), before)
			}).EnsureSuccess();
		}

		public static async ValueTask ReportElementReorderAsync(this CashCtrlClient that, int[] ids, int target, bool? before = default) {
			var response = await that.PostAsync<ActionResponse>("report/element/reorder.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(target), target), new(nameof(before), before)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static void ReportElementUpdate(this CashCtrlClient that, ReportElement reportElement) {
			that.Post<UpdateResponse>("report/element/update.json", reportElement.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask ReportElementUpdateAsync(this CashCtrlClient that, ReportElement reportElement) {
			var response = await that.PostAsync<UpdateResponse>("report/element/update.json", reportElement.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
