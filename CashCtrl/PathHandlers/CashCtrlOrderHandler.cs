using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlOrderHandler: CashCtrlEntityHandler<Order> {
		private readonly IReadOnlyDictionary<string, CashCtrlPathHandler> childHandlers;

		public CashCtrlOrderHandler(OneOf.OneOf<int, Order> idOrEntity) : base(idOrEntity) {
			this.childHandlers = CashCtrlRootHandler.CreateHandlerDictionary(
					new CashCtrlOrderBookEntriesHandler(this.Id)
			);
		}

		public override bool IsContainer => true;

		public override IEnumerable<CashCtrlPathHandler> GetAllChildHandlers(CashCtrlClient client) {
			return this.childHandlers.Values;
		}

		protected override Order ReadEntity(CashCtrlClient client) {
			return client.OrderRead(this.Id);
		}

		public override bool TryGetChildHandler(string name, out CashCtrlPathHandler handler) {
			return this.childHandlers.TryGetValue(name, out handler);
		}
	}
}
