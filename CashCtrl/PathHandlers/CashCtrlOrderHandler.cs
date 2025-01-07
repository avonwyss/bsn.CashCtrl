using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlOrderHandler: CashCtrlEntityHandler<Order> {
		private readonly IReadOnlyDictionary<string, CashCtrlPathHandler> childHandlers;

		public CashCtrlOrderHandler(OneOf<int, Order> idOrEntity): base(idOrEntity) {
			this.childHandlers = CashCtrlRootHandler.CreateHandlerDictionary(
					new CashCtrlOrderBookEntriesHandler(this.Id)
			);
		}

		public override bool IsContainer => true;

		protected override void CreateEntity(CashCtrlClient client, Order entity) {
			client.OrderCreate(entity);
		}

		public override IEnumerable<CashCtrlPathHandler> GetChildHandlers(CashCtrlClient client, object parameters) {
			return this.childHandlers.Values;
		}

		protected override Order ReadEntity(CashCtrlClient client) {
			return client.OrderRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.OrderDelete(this.Id);
		}

		public override bool TryGetChildHandler(string name, out CashCtrlPathHandler handler) {
			return this.childHandlers.TryGetValue(name, out handler);
		}

		protected override void UpdateEntity(CashCtrlClient client, Order entity) {
			client.OrderUpdate(entity);
		}
	}
}
