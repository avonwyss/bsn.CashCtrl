using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;
using bsn.CashCtrl.Response;
using bsn.HttpClientSync;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static (string ContentType, Stream Stream)  FileGet(this CashCtrlClient that, int id) {
			var content = that.Get($"file/get", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			});
			return (content.Headers.ContentType.MediaType, content.ReadAsStream());
		}

		public static Entities.File FileRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<Entities.File>>("file/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static Entities.File[] FileList(this CashCtrlClient that, FileQuery query = default) {
			return that.Get<ListResponse<Entities.File>>("file/list.json", query?.ToParameters()).Data;
		}

		public static Stream FileList(this CashCtrlClient that, CashCtrlDownloadFormat format, FileQuery query = default) {
			return that.Get($"file/list.{format.ToString().ToLowerInvariant()}", query?.ToParameters()).ReadAsStream();
		}

		public static PreparedFile[] FilePrepare(this CashCtrlClient that, params Entities.File[] files) {
			return that.Post<PrepareFileResponse>("file/prepare.json", new KeyValuePair<string, object>[] {
					new(nameof(files), files)
			}).GetDataOrThrow();
		}

		public static void FilePut(this CashCtrlClient that, PreparedFile preparedFile, HttpContent content) {
			FilePutAsync(that, preparedFile, content).AsTask().GetAwaiter().GetResult();
		}

		public static async ValueTask FilePutAsync(this CashCtrlClient that, PreparedFile preparedFile, HttpContent content, CancellationToken cancellationToken = default) {
			var response = await that.HttpClient.PutAsync(preparedFile.WriteUrl, content, cancellationToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
		}

		public static void FilePersist(this CashCtrlClient that, params int[] ids) {
			that.Post<ActionResponse>("file/persist.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static int FileCreate(this CashCtrlClient that, int id, Entities.File file) {
			return that.Post<CreateResponse>("file/create.json", file.ToParameters().Append(new(nameof(id), id))).GetInsertIdOrThrow();
		}

		public static void FileUpdate(this CashCtrlClient that, Entities.File file) {
			that.Post<UpdateResponse>("file/update.json", file.ToParameters()).EnsureSuccess();
		}

		public static void FileDelete(this CashCtrlClient that, int[] ids, bool force) {
			that.Post<DeleteResponse>("file/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids),
					new(nameof(force), force)
			}).EnsureSuccess();
		}

		public static void FileDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("file/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static void FileEmptyArchive(this CashCtrlClient that) {
			that.Post<ActionResponse>("file/empty_archive.json", null).EnsureSuccess();
		}

		public static void FileRestore(this CashCtrlClient that, params int[] ids) {
			that.Post<ActionResponse>("file/restore.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}
	}
}
