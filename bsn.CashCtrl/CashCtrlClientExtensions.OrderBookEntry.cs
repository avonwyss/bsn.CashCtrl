using System.Collections.Generic;
using System.Linq;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static OrderBookEntry OrderBookEntryRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<OrderBookEntry>>("order/bookentry/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static OrderBookEntry[] OrderBookEntryList(this CashCtrlClient that, int id) {
			return that.Get<ListResponse<OrderBookEntry>>("order/bookentry/list.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).Data;
		}

		public static int OrderBookEntryCreate(this CashCtrlClient that, OrderBookEntry orderBookEntry, params int[] orderIds) {
			return that.Post<CreateResponse>("order/bookentry/create.json", orderBookEntry.ToParameters().Append(new(nameof(orderIds), orderIds))).GetInsertIdOrThrow();
		}

		public static void OrderBookEntryUpdate(this CashCtrlClient that, OrderBookEntry orderBookEntry) {
			that.Post<UpdateResponse>("order/bookentry/update.json", orderBookEntry.ToParameters()).EnsureSuccess();
		}

		public static void OrderBookEntryDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("order/bookentry/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}
	}
}
