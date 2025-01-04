using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int OrderBookEntryCreate(this CashCtrlClient that, OrderBookEntry orderBookEntry, params int[] orderIds) {
			return that.Post<CreateResponse>("order/bookentry/create.json", orderBookEntry.ToParameters().Append(new(nameof(orderIds), orderIds))).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> OrderBookEntryCreateAsync(this CashCtrlClient that, OrderBookEntry orderBookEntry, params int[] orderIds) {
			var response = await that.PostAsync<CreateResponse>("order/bookentry/create.json", orderBookEntry.ToParameters().Append(new(nameof(orderIds), orderIds))).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void OrderBookEntryDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("order/bookentry/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask OrderBookEntryDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("order/bookentry/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static OrderBookEntry[] OrderBookEntryList(this CashCtrlClient that, int id) {
			return that.Get<ListResponse<OrderBookEntry>>("order/bookentry/list.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).Data;
		}

		public static async ValueTask<OrderBookEntry[]> OrderBookEntryListAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ListResponse<OrderBookEntry>>("order/bookentry/list.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).ConfigureAwait(false);
			return response.Data;
		}

		public static OrderBookEntry OrderBookEntryRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<OrderBookEntry>>("order/bookentry/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<OrderBookEntry> OrderBookEntryReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<OrderBookEntry>>("order/bookentry/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void OrderBookEntryUpdate(this CashCtrlClient that, OrderBookEntry orderBookEntry) {
			that.Post<UpdateResponse>("order/bookentry/update.json", orderBookEntry.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask OrderBookEntryUpdateAsync(this CashCtrlClient that, OrderBookEntry orderBookEntry) {
			var response = await that.PostAsync<UpdateResponse>("order/bookentry/update.json", orderBookEntry.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
