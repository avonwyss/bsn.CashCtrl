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
		public static int FileCreate(this CashCtrlClient that, int id, Entities.File file) {
			return that.Post<CreateResponse>("file/create.json", file.ToParameters().Append(new(nameof(id), id))).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> FileCreateAsync(this CashCtrlClient that, int id, Entities.File file) {
			var response = await that.PostAsync<CreateResponse>("file/create.json", file.ToParameters().Append(new(nameof(id), id))).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void FileDelete(this CashCtrlClient that, int[] ids, bool force) {
			that.Post<DeleteResponse>("file/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(force), force)
			}).EnsureSuccess();
		}

		public static void FileDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("file/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask FileDeleteAsync(this CashCtrlClient that, int[] ids, bool force) {
			var response = await that.PostAsync<DeleteResponse>("file/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(force), force)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static async ValueTask FileDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("file/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static void FileEmptyArchive(this CashCtrlClient that) {
			that.Post<ActionResponse>("file/empty_archive.json", null).EnsureSuccess();
		}

		public static async ValueTask FileEmptyArchiveAsync(this CashCtrlClient that) {
			var response = await that.PostAsync<ActionResponse>("file/empty_archive.json", null).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static (string ContentType, Stream Stream) FileGet(this CashCtrlClient that, int id) {
			var content = that.Get("file/get", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			});
			return (content.Headers.ContentType.MediaType, content.ReadAsStream());
		}

		public static async ValueTask<(string ContentType, Stream Stream)> FileGetAsync(this CashCtrlClient that, int id) {
			var content = await that.GetAsync("file/get", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).ConfigureAwait(false);
			return (content.Headers.ContentType.MediaType, await content.ReadAsStreamAsync().ConfigureAwait(false));
		}

		public static Entities.File[] FileList(this CashCtrlClient that, FileQuery query = default) {
			return that.Get<ListResponse<Entities.File>>("file/list.json", query?.ToParameters()).Data;
		}

		public static Stream FileList(this CashCtrlClient that, CashCtrlDownloadFormat format, FileQuery query = default) {
			return that.Get($"file/list.{format.ToString().ToLowerInvariant()}", query?.ToParameters()).ReadAsStream();
		}

		public static async ValueTask<Entities.File[]> FileListAsync(this CashCtrlClient that, FileQuery query = default) {
			var response = await that.GetAsync<ListResponse<Entities.File>>("file/list.json", query?.ToParameters()).ConfigureAwait(false);
			return response.Data;
		}

		public static async ValueTask<Stream> FileListAsync(this CashCtrlClient that, CashCtrlDownloadFormat format, FileQuery query = default) {
			var content = await that.GetAsync($"file/list.{format.ToString().ToLowerInvariant()}", query?.ToParameters()).ConfigureAwait(false);
			return await content.ReadAsStreamAsync().ConfigureAwait(false);
		}

		public static void FilePersist(this CashCtrlClient that, params int[] ids) {
			that.Post<ActionResponse>("file/persist.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask FilePersistAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<ActionResponse>("file/persist.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static PreparedFile[] FilePrepare(this CashCtrlClient that, params Entities.File[] files) {
			return that.Post<PrepareFileResponse>("file/prepare.json", new KeyValuePair<string, object>[] {
					new(nameof(files), files)
			}).GetDataOrThrow();
		}

		public static async ValueTask<PreparedFile[]> FilePrepareAsync(this CashCtrlClient that, params Entities.File[] files) {
			var response = await that.PostAsync<PrepareFileResponse>("file/prepare.json", new KeyValuePair<string, object>[] {
					new(nameof(files), files)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void FilePut(this CashCtrlClient that, PreparedFile preparedFile, HttpContent content) {
			FilePutAsync(that, preparedFile, content).AsTask().GetAwaiter().GetResult();
		}

		public static async ValueTask FilePutAsync(this CashCtrlClient that, PreparedFile preparedFile, HttpContent content, CancellationToken cancellationToken = default) {
			var response = await that.HttpClient.PutAsync(preparedFile.WriteUrl, content, cancellationToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
		}

		public static Entities.File FileRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<Entities.File>>("file/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<Entities.File> FileReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<Entities.File>>("file/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void FileRestore(this CashCtrlClient that, params int[] ids) {
			that.Post<ActionResponse>("file/restore.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask FileRestoreAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<ActionResponse>("file/restore.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static void FileUpdate(this CashCtrlClient that, Entities.File file) {
			that.Post<UpdateResponse>("file/update.json", file.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask FileUpdateAsync(this CashCtrlClient that, Entities.File file) {
			var response = await that.PostAsync<UpdateResponse>("file/update.json", file.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
