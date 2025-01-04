using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int SequenceNumberCreate(this CashCtrlClient that, SequenceNumber sequenceNumber) {
			return that.Post<CreateResponse>("sequencenumber/create.json", sequenceNumber.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> SequenceNumberCreateAsync(this CashCtrlClient that, SequenceNumber sequenceNumber) {
			var response = await that.PostAsync<CreateResponse>("sequencenumber/create.json", sequenceNumber.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void SequenceNumberDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("sequencenumber/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask SequenceNumberDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("sequencenumber/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static string SequenceNumberGet(this CashCtrlClient that, int id, int? categoryId = default, DateTime? date = default) {
			return that.GetString("sequencenumber/get", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new(nameof(categoryId), categoryId), new(nameof(date), date)
			});
		}

		public static string SequenceNumberGet(this CashCtrlClient that, SequenceNumberType type, int? categoryId = default, DateTime? date = default) {
			return that.GetString("sequencenumber/get", new KeyValuePair<string, object>[] {
					new(nameof(type), type), new(nameof(categoryId), categoryId), new(nameof(date), date)
			});
		}

		public static async ValueTask<string> SequenceNumberGetAsync(this CashCtrlClient that, int id, int? categoryId = default, DateTime? date = default) {
			return await that.GetStringAsync("sequencenumber/get", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new(nameof(categoryId), categoryId), new(nameof(date), date)
			}).ConfigureAwait(false);
		}

		public static async ValueTask<string> SequenceNumberGetAsync(this CashCtrlClient that, SequenceNumberType type, int? categoryId = default, DateTime? date = default) {
			return await that.GetStringAsync("sequencenumber/get", new KeyValuePair<string, object>[] {
					new(nameof(type), type), new(nameof(categoryId), categoryId), new(nameof(date), date)
			}).ConfigureAwait(false);
		}

		public static SequenceNumber[] SequenceNumberList(this CashCtrlClient that) {
			return that.Get<ListResponse<SequenceNumber>>("sequencenumber/list.json", null).Data;
		}

		public static async ValueTask<SequenceNumber[]> SequenceNumberListAsync(this CashCtrlClient that) {
			var response = await that.GetAsync<ListResponse<SequenceNumber>>("sequencenumber/list.json", null).ConfigureAwait(false);
			return response.Data;
		}

		public static SequenceNumber SequenceNumberRead(this CashCtrlClient that, int id, int? categoryId = default, DateTime? date = default) {
			return that.Get<ReadResponse<SequenceNumber>>("sequencenumber/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id), new KeyValuePair<string, object>(nameof(categoryId), categoryId), new KeyValuePair<string, object>(nameof(date), date)
			}).GetDataOrThrow();
		}

		public static SequenceNumber SequenceNumberRead(this CashCtrlClient that, SequenceNumberType type, int? categoryId = default, DateTime? date = default) {
			return that.Get<ReadResponse<SequenceNumber>>("sequencenumber/read.json", new[] {
					new KeyValuePair<string, object>(nameof(type), type), new KeyValuePair<string, object>(nameof(categoryId), categoryId), new KeyValuePair<string, object>(nameof(date), date)
			}).GetDataOrThrow();
		}

		public static async ValueTask<SequenceNumber> SequenceNumberReadAsync(this CashCtrlClient that, int id, int? categoryId = default, DateTime? date = default) {
			var response = await that.GetAsync<ReadResponse<SequenceNumber>>("sequencenumber/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id), new KeyValuePair<string, object>(nameof(categoryId), categoryId), new KeyValuePair<string, object>(nameof(date), date)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static async ValueTask<SequenceNumber> SequenceNumberReadAsync(this CashCtrlClient that, SequenceNumberType type, int? categoryId = default, DateTime? date = default) {
			var response = await that.GetAsync<ReadResponse<SequenceNumber>>("sequencenumber/read.json", new[] {
					new KeyValuePair<string, object>(nameof(type), type), new KeyValuePair<string, object>(nameof(categoryId), categoryId), new KeyValuePair<string, object>(nameof(date), date)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void SequenceNumberUpdate(this CashCtrlClient that, SequenceNumber sequenceNumber) {
			that.Post<UpdateResponse>("sequencenumber/update.json", sequenceNumber.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask SequenceNumberUpdateAsync(this CashCtrlClient that, SequenceNumber sequenceNumber) {
			var response = await that.PostAsync<UpdateResponse>("sequencenumber/update.json", sequenceNumber.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
