using System;
using System.Collections.Generic;
using System.IO;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Http;
using bsn.CashCtrl.Response;

using Newtonsoft.Json.Linq;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static ReportElement ReportElementRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<ReportElement>>("report/element/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static int ReportElementCreate(this CashCtrlClient that, ReportElement reportElement) {
			return that.Post<CreateResponse>("report/element/create.json", reportElement.ToParameters()).GetInsertIdOrThrow();
		}

		public static void ReportElementUpdate(this CashCtrlClient that, ReportElement reportElement) {
			that.Post<UpdateResponse>("report/element/update.json", reportElement.ToParameters()).EnsureSuccess();
		}

		public static void ReportElementDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("report/element/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static void ReportElementReorder(this CashCtrlClient that, int[] ids, int target, bool? before = default) {
			that.Post<ActionResponse>("report/element/reorder.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids),
					new(nameof(target), target),
					new(nameof(before), before)
			}).EnsureSuccess();
		}

		public static ListResponse<JObject> ReportElementData(this CashCtrlClient that, int elementId, int? fiscalPeriodId = default, DateTime? startDate = default, DateTime? endDate = default, string language = default, string sort = default) {
			return that.Get<ListResponse<JObject>>("report/element/data.json", new KeyValuePair<string, object>[] {
					new(nameof(elementId), elementId),
					new(nameof(fiscalPeriodId), fiscalPeriodId),
					new(nameof(startDate), startDate.ToCashCtrlString(true)),
					new(nameof(endDate), endDate.ToCashCtrlString(true)),
					new(nameof(language), language),
					new(nameof(sort), sort)
			});
		}

		public static string ReportElementHtml(this CashCtrlClient that, int elementId, int? fiscalPeriodId = default, DateTime? startDate = default, DateTime? endDate = default, string language = default, string sort = default) {
			return that.GetString("report/element/data.json", new KeyValuePair<string, object>[] {
					new(nameof(elementId), elementId),
					new(nameof(fiscalPeriodId), fiscalPeriodId),
					new(nameof(startDate), startDate.ToCashCtrlString(true)),
					new(nameof(endDate), endDate.ToCashCtrlString(true)),
					new(nameof(language), language),
					new(nameof(sort), sort)
			});
		}

		public static ReportMeta ReportElementMeta(this CashCtrlClient that, int elementId, int? fiscalPeriodId = default, DateTime? startDate = default, DateTime? endDate = default, string language = default, string sort = default) {
			return that.Get<ReadResponse<ReportMeta>>("report/element/meta.json", new KeyValuePair<string, object>[] {
					new(nameof(elementId), elementId),
					new(nameof(fiscalPeriodId), fiscalPeriodId),
					new(nameof(startDate), startDate.ToCashCtrlString(true)),
					new(nameof(endDate), endDate.ToCashCtrlString(true)),
					new(nameof(language), language),
					new(nameof(sort), sort)
			}).GetDataOrThrow();
		}

		public static Stream ReportElementDownload(this CashCtrlClient that, CashCtrlDownloadFormat format, int elementId, int? fiscalPeriodId = default, DateTime? startDate = default, DateTime? endDate = default, string language = default, string sort = default) {
			return that.Get($"report/element/download.{format.ToString().ToLowerInvariant()}", new KeyValuePair<string, object>[] {
					new(nameof(elementId), elementId),
					new(nameof(fiscalPeriodId), fiscalPeriodId),
					new(nameof(startDate), startDate.ToCashCtrlString(true)),
					new(nameof(endDate), endDate.ToCashCtrlString(true)),
					new(nameof(language), language),
					new(nameof(sort), sort)
			}).ReadAsStream();
		}
	}
}
