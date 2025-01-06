using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlOrderBookEntriesHandler: CashCtrlCollectionHandler<OrderBookEntry> {
		public CashCtrlOrderBookEntriesHandler(int orderId): base("bookentry") {
			this.OrderId = orderId;
		}

		public int OrderId {
			get;
		}

		protected override CashCtrlEntityHandler<OrderBookEntry> GetEntityHandler(OneOf<int, OrderBookEntry> idOrEntity) {
			return new CashCtrlOrderBookEntryHandler(idOrEntity);
		}

		protected override IEnumerable<OrderBookEntry> ListEntities(CashCtrlClient client) {
			return client.OrderBookEntryList(this.OrderId);
		}
	}
}
