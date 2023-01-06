using System;
using System.Collections.Generic;
using System.IO;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Http;
using bsn.CashCtrl.Query;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static Journal JournalRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<Journal>>("journal/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static Journal[] JournalList(this CashCtrlClient that, JournalQuery query = default) {
			return that.Get<ListResponse<Journal>>("journal/list.json", query?.ToParameters()).Data;
		}

		public static Stream JournalList(this CashCtrlClient that, CashCtrlDownloadFormat format, JournalQuery query = default) {
			return that.Get($"journal/list.{format.ToString().ToLowerInvariant()}", query?.ToParameters()).ReadAsStream();
		}

		public static int JournalCreate(this CashCtrlClient that, Journal journal) {
			return that.Post<CreateResponse>("journal/create.json", journal.ToParameters()).GetInsertIdOrThrow();
		}

		public static void JournalUpdate(this CashCtrlClient that, Journal journal) {
			that.Post<UpdateResponse>("journal/update.json", journal.ToParameters()).EnsureSuccess();
		}

		public static void JournalDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("journal/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static void JournalAttachmentsUpdate(this CashCtrlClient that, int id, params int[] fileIds) {
			that.Post<ActionResponse>("journal/update_attachments.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id),
					new(nameof(fileIds), fileIds)
			}).EnsureSuccess();
		}

		public static void JournalRecurrenceUpdate(this CashCtrlClient that, int id, JournalRecurrence? recurrence = default, int? daysBefore = default, DateTime? startDate = default, DateTime? endDate = default, NotifyType? notifyType = default, string notifyEmail = default,
				int? notifyPersonId = default, int? notifyUserId = default) {
			that.Post<UpdateResponse>("journal/update_recurrence.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id),
					new(nameof(recurrence), recurrence),
					new(nameof(daysBefore), daysBefore),
					new(nameof(startDate), startDate.ToCashCtrlString(true)),
					new(nameof(endDate), endDate.ToCashCtrlString(true)),
					new(nameof(notifyType), notifyType),
					new(nameof(notifyEmail), notifyEmail),
					new(nameof(notifyPersonId), notifyPersonId),
					new(nameof(notifyUserId), notifyUserId)
			}).EnsureSuccess();
		}
	}
}
