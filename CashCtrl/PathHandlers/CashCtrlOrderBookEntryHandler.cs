using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlOrderBookEntryHandler: CashCtrlEntityHandler<OrderBookEntry> {
		public CashCtrlOrderBookEntryHandler(OneOf<int, OrderBookEntry> idOrEntity): base(idOrEntity) { }

		protected override void CreateEntity(CashCtrlClient client, OrderBookEntry entity) {
			client.OrderBookEntryCreate(entity);
		}

		protected override OrderBookEntry ReadEntity(CashCtrlClient client) {
			return client.OrderBookEntryRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.OrderBookEntryDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, OrderBookEntry entity) {
			client.OrderBookEntryUpdate(entity);
		}
	}
}
