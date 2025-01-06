using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlInventoryUnitHandler: CashCtrlEntityHandler<InventoryUnit> {
		public CashCtrlInventoryUnitHandler(OneOf<int, InventoryUnit> idOrEntity): base(idOrEntity) { }

		protected override InventoryUnit ReadEntity(CashCtrlClient client) {
			return client.InventoryUnitRead(this.Id);
		}
	}
}
