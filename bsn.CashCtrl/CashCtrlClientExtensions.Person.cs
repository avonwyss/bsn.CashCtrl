using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;
using bsn.CashCtrl.Response;
using bsn.HttpClientSync;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static Person PersonRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<Person>>("person/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static Person[] PersonList(this CashCtrlClient that, PersonQuery query = default) {
			return that.Get<ListResponse<Person>>("person/list.json", query?.ToParameters()).Data;
		}

		public static Stream PersonList(this CashCtrlClient that, CashCtrlDownloadFormat format, PersonQuery query = default) {
			return that.Get($"person/list.{format.ToString().ToLowerInvariant()}", query?.ToParameters()).ReadAsStream();
		}

		public static int PersonCreate(this CashCtrlClient that, Person person) {
			return that.Post<CreateResponse>("person/create.json", person.ToParameters()).GetInsertIdOrThrow();
		}

		public static void PersonUpdate(this CashCtrlClient that, Person person) {
			that.Post<UpdateResponse>("person/update.json", person.ToParameters()).EnsureSuccess();
		}

		public static void PersonDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("person/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static void PersonCategorize(this CashCtrlClient that, int[] ids, int target) {
			that.Post<ActionResponse>("person/categorize.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids),
					new(nameof(target), target)
			}).EnsureSuccess();
		}

		public static void PersonAttachmentsUpdate(this CashCtrlClient that, int id, params int[] fileIds) {
			that.Post<ActionResponse>("person/update_attachments.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id),
					new(nameof(fileIds), fileIds)
			}).EnsureSuccess();
		}
	}
}
