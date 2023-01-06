using System;
using System.Collections.Generic;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static SequenceNumber SequenceNumberRead(this CashCtrlClient that, int id, int? categoryId = default, DateTime? date = default) {
			return that.Get<ReadResponse<SequenceNumber>>("sequencenumber/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id),
					new KeyValuePair<string, object>(nameof(categoryId), categoryId),
					new KeyValuePair<string, object>(nameof(date), date)
			}).GetDataOrThrow();
		}

		public static SequenceNumber SequenceNumberRead(this CashCtrlClient that, SequenceNumberType type, int? categoryId = default, DateTime? date = default) {
			return that.Get<ReadResponse<SequenceNumber>>("sequencenumber/read.json", new[] {
					new KeyValuePair<string, object>(nameof(type), type),
					new KeyValuePair<string, object>(nameof(categoryId), categoryId),
					new KeyValuePair<string, object>(nameof(date), date)
			}).GetDataOrThrow();
		}

		public static string SequenceNumberGet(this CashCtrlClient that, int id, int? categoryId = default, DateTime? date = default) {
			return that.GetString($"sequencenumber/get", new KeyValuePair<string, object>[] {
					new(nameof(id), id),
					new(nameof(categoryId), categoryId),
					new(nameof(date), date)
			});
		}

		public static string SequenceNumberGet(this CashCtrlClient that, SequenceNumberType type, int? categoryId = default, DateTime? date = default) {
			return that.GetString($"sequencenumber/get", new KeyValuePair<string, object>[] {
					new(nameof(type), type),
					new(nameof(categoryId), categoryId),
					new(nameof(date), date)
			});
		}

		public static SequenceNumber[] SequenceNumberList(this CashCtrlClient that) {
			return that.Get<ListResponse<SequenceNumber>>("sequencenumber/list.json", null).Data;
		}

		public static int SequenceNumberCreate(this CashCtrlClient that, SequenceNumber sequenceNumber) {
			return that.Post<CreateResponse>("sequencenumber/create.json", sequenceNumber.ToParameters()).GetInsertIdOrThrow();
		}

		public static void SequenceNumberUpdate(this CashCtrlClient that, SequenceNumber sequenceNumber) {
			that.Post<UpdateResponse>("sequencenumber/update.json", sequenceNumber.ToParameters()).EnsureSuccess();
		}

		public static void SequenceNumberDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("sequencenumber/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}
	}
}
