using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlOrderBookEntryHandler: CashCtrlEntityHandler<OrderBookEntry> {
		public CashCtrlOrderBookEntryHandler(OneOf<int, OrderBookEntry> idOrEntity): base(idOrEntity) { }

		protected override OrderBookEntry ReadEntity(CashCtrlClient client) {
			return client.OrderBookEntryRead(this.Id);
		}
	}
}
