using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;
using bsn.CashCtrl.Response;
using bsn.HttpClientSync;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int JournalImportCreate(this CashCtrlClient that, JournalImport journal) {
			return that.Post<CreateResponse>("journal/import/create.json", journal.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> JournalImportCreateAsync(this CashCtrlClient that, JournalImport journal) {
			var response = await that.PostAsync<CreateResponse>("journal/import/create.json", journal.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void JournalImportEntriesConfirm(this CashCtrlClient that, params int[] ids) {
			that.Post<ActionResponse>("journal/import/entry/confirm.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask JournalImportEntriesConfirmAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<ActionResponse>("journal/import/entry/confirm.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static void JournalImportEntriesIgnore(this CashCtrlClient that, params int[] ids) {
			that.Post<ActionResponse>("journal/import/entry/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask JournalImportEntriesIgnoreAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<ActionResponse>("journal/import/entry/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static void JournalImportEntriesRestore(this CashCtrlClient that, params int[] ids) {
			that.Post<ActionResponse>("journal/import/entry/restore.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask JournalImportEntriesRestoreAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<ActionResponse>("journal/import/entry/restore.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static void JournalImportEntriesUnconfirm(this CashCtrlClient that, params int[] ids) {
			that.Post<ActionResponse>("journal/import/entry/unconfirm.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask JournalImportEntriesUnconfirmAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<ActionResponse>("journal/import/entry/unconfirm.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static JournalImportEntry[] JournalImportEntryList(this CashCtrlClient that, int importId, JournalImportEntryQuery query = default) {
			var parameters = new List<KeyValuePair<string, object>> {
					new(nameof(importId), importId)
			};
			if (query != null) {
				parameters.AddRange(query.ToParameters());
			}
			return that.Get<ListResponse<JournalImportEntry>>("journal/import/entry/list.json", parameters).Data;
		}

		public static Stream JournalImportEntryList(this CashCtrlClient that, CashCtrlDownloadFormat format, int importId, JournalImportEntryQuery query = default) {
			var parameters = new List<KeyValuePair<string, object>> {
					new(nameof(importId), importId)
			};
			if (query != null) {
				parameters.AddRange(query.ToParameters());
			}
			return that.Get($"journal/import/entry/list.{format.ToString().ToLowerInvariant()}", parameters).ReadAsStream();
		}

		public static async ValueTask<JournalImportEntry[]> JournalImportEntryListAsync(this CashCtrlClient that, int importId, JournalImportEntryQuery query = default) {
			var parameters = new List<KeyValuePair<string, object>> {
					new(nameof(importId), importId)
			};
			if (query != null) {
				parameters.AddRange(query.ToParameters());
			}
			var response = await that.GetAsync<ListResponse<JournalImportEntry>>("journal/import/entry/list.json", parameters).ConfigureAwait(false);
			return response.Data;
		}

		public static async ValueTask<Stream> JournalImportEntryListAsync(this CashCtrlClient that, CashCtrlDownloadFormat format, int importId, JournalImportEntryQuery query = default) {
			var parameters = new List<KeyValuePair<string, object>> {
					new(nameof(importId), importId)
			};
			if (query != null) {
				parameters.AddRange(query.ToParameters());
			}
			var content = await that.GetAsync($"journal/import/entry/list.{format.ToString().ToLowerInvariant()}", parameters).ConfigureAwait(false);
			return await content.ReadAsStreamAsync().ConfigureAwait(false);
		}

		public static JournalImportEntry JournalImportEntryRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<JournalImportEntry>>("journal/import/entry/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<JournalImportEntry> JournalImportEntryReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<JournalImportEntry>>("journal/import/entry/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void JournalImportEntryUpdate(this CashCtrlClient that, JournalImportEntry journalImportEntry) {
			that.Post<UpdateResponse>("journal/import/entry/update.json", journalImportEntry.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask JournalImportEntryUpdateAsync(this CashCtrlClient that, JournalImportEntry journalImportEntry) {
			var response = await that.PostAsync<UpdateResponse>("journal/import/entry/update.json", journalImportEntry.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static void JournalImportExecute(this CashCtrlClient that, int id) {
			that.Post<ActionResponse>("journal/import/execute.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).EnsureSuccess();
		}

		public static async ValueTask JournalImportExecuteAsync(this CashCtrlClient that, int id) {
			var response = await that.PostAsync<ActionResponse>("journal/import/execute.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static JournalImport[] JournalImportList(this CashCtrlClient that, CashCtrlDirection? dir = default, int? fiscalPeriodId = default, string query = default, string sort = default) {
			return that.Get<ListResponse<JournalImport>>("journal/import/list.json", new KeyValuePair<string, object>[] {
					new(nameof(dir), dir), new(nameof(fiscalPeriodId), fiscalPeriodId), new(nameof(query), query), new(nameof(sort), sort)
			}).Data;
		}

		public static async ValueTask<JournalImport[]> JournalImportListAsync(this CashCtrlClient that, CashCtrlDirection? dir = default, int? fiscalPeriodId = default, string query = default, string sort = default) {
			var response = await that.GetAsync<ListResponse<JournalImport>>("journal/import/list.json", new KeyValuePair<string, object>[] {
					new(nameof(dir), dir), new(nameof(fiscalPeriodId), fiscalPeriodId), new(nameof(query), query), new(nameof(sort), sort)
			}).ConfigureAwait(false);
			return response.Data;
		}

		public static JournalImport JournalImportRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<JournalImport>>("journal/import/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<JournalImport> JournalImportReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<JournalImport>>("journal/import/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}
	}
}
