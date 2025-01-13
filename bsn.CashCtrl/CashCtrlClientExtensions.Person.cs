using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;
using bsn.CashCtrl.Response;
using bsn.HttpClientSync;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static void PersonAttachmentsUpdate(this CashCtrlClient that, int id, params int[] fileIds) {
			that.Post<ActionResponse>("person/update_attachments.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new("attachments", CashCtrlAttachment.Create(fileIds))
			}).EnsureSuccess();
		}

		public static async ValueTask PersonAttachmentsUpdateAsync(this CashCtrlClient that, int id, params int[] fileIds) {
			var response = await that.PostAsync<ActionResponse>("person/update_attachments.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new("attachments", CashCtrlAttachment.Create(fileIds))
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static void PersonCategorize(this CashCtrlClient that, int[] ids, int target) {
			that.Post<ActionResponse>("person/categorize.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(target), target)
			}).EnsureSuccess();
		}

		public static async ValueTask PersonCategorizeAsync(this CashCtrlClient that, int[] ids, int target) {
			var response = await that.PostAsync<ActionResponse>("person/categorize.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(target), target)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static int PersonCreate(this CashCtrlClient that, Person person) {
			return that.Post<CreateResponse>("person/create.json", person.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> PersonCreateAsync(this CashCtrlClient that, Person person) {
			var response = await that.PostAsync<CreateResponse>("person/create.json", person.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void PersonDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("person/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask PersonDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("person/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static Person[] PersonList(this CashCtrlClient that, PersonQuery query = default) {
			return that.Get<ListResponse<Person>>("person/list.json", query?.ToParameters()).Data;
		}

		public static Stream PersonList(this CashCtrlClient that, CashCtrlDownloadFormat format, PersonQuery query = default) {
			return that.Get($"person/list.{format.ToString().ToLowerInvariant()}", query?.ToParameters()).ReadAsStream();
		}

		public static async ValueTask<Person[]> PersonListAsync(this CashCtrlClient that, PersonQuery query = default) {
			var response = await that.GetAsync<ListResponse<Person>>("person/list.json", query?.ToParameters()).ConfigureAwait(false);
			return response.Data;
		}

		public static async ValueTask<Stream> PersonListAsync(this CashCtrlClient that, CashCtrlDownloadFormat format, PersonQuery query = default) {
			var content = await that.GetAsync($"person/list.{format.ToString().ToLowerInvariant()}", query?.ToParameters()).ConfigureAwait(false);
			return await content.ReadAsStreamAsync().ConfigureAwait(false);
		}

		public static Person PersonRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<Person>>("person/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<Person> PersonReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<Person>>("person/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void PersonUpdate(this CashCtrlClient that, Person person) {
			that.Post<UpdateResponse>("person/update.json", person.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask PersonUpdateAsync(this CashCtrlClient that, Person person) {
			var response = await that.PostAsync<UpdateResponse>("person/update.json", person.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
