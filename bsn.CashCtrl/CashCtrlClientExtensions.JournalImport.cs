using System.Collections.Generic;
using System.IO;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Http;
using bsn.CashCtrl.Query;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static JournalImport JournalImportRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<JournalImport>>("journal/import/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static JournalImport[] JournalImportList(this CashCtrlClient that, CashCtrlDirection? dir = default, int? fiscalPeriodId = default, string query = default, string sort = default) {
			return that.Get<ListResponse<JournalImport>>("journal/import/list.json", new KeyValuePair<string, object>[] {
					new(nameof(dir), dir),
					new(nameof(fiscalPeriodId), fiscalPeriodId),
					new(nameof(query), query),
					new(nameof(sort), sort)
			}).Data;
		}

		public static int JournalImportCreate(this CashCtrlClient that, JournalImport journal) {
			return that.Post<CreateResponse>("journal/import/create.json", journal.ToParameters()).GetInsertIdOrThrow();
		}

		public static void JournalImportExecute(this CashCtrlClient that, int id) {
			that.Post<ActionResponse>("journal/import/execute.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).EnsureSuccess();
		}

		public static JournalImportEntry JournalImportEntryRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<JournalImportEntry>>("journal/import/entry/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static JournalImportEntry[] JournalImportEntryList(this CashCtrlClient that, int importId, JournalImportEntryQuery query = default) {
			var parameters = new List<KeyValuePair<string, object>>() {
					new(nameof(importId), importId)
			};
			if (query != null) {
				parameters.AddRange(query.ToParameters());
			}
			return that.Get<ListResponse<JournalImportEntry>>("journal/import/entry/list.json", parameters).Data;
		}

		public static Stream JournalImportEntryList(this CashCtrlClient that, CashCtrlDownloadFormat format, int importId, JournalImportEntryQuery query = default) {
			var parameters = new List<KeyValuePair<string, object>>() {
					new(nameof(importId), importId)
			};
			if (query != null) {
				parameters.AddRange(query.ToParameters());
			}
			return that.Get($"journal/import/entry/list.{format.ToString().ToLowerInvariant()}", parameters).ReadAsStream();
		}

		public static void JournalImportEntryUpdate(this CashCtrlClient that, JournalImportEntry journalImportEntry) {
			that.Post<UpdateResponse>("journal/import/entry/update.json", journalImportEntry.ToParameters()).EnsureSuccess();
		}

		public static void JournalImportEntriesIgnore(this CashCtrlClient that, params int[] ids) {
			that.Post<ActionResponse>("journal/import/entry/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static void JournalImportEntriesConfirm(this CashCtrlClient that, params int[] ids) {
			that.Post<ActionResponse>("journal/import/entry/confirm.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static void JournalImportEntriesRestore(this CashCtrlClient that, params int[] ids) {
			that.Post<ActionResponse>("journal/import/entry/restore.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static void JournalImportEntriesUnconfirm(this CashCtrlClient that, params int[] ids) {
			that.Post<ActionResponse>("journal/import/entry/unconfirm.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}
	}
}
