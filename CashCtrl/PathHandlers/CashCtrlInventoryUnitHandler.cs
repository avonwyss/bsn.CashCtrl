using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlInventoryUnitHandler: CashCtrlEntityHandler<InventoryUnit> {
		public CashCtrlInventoryUnitHandler(OneOf<int, InventoryUnit> idOrEntity): base(idOrEntity) { }

		protected override int CreateEntity(CashCtrlClient client, InventoryUnit entity) {
			return client.InventoryUnitCreate(entity);
		}

		protected override InventoryUnit ReadEntity(CashCtrlClient client) {
			return client.InventoryUnitRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.InventoryUnitDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, InventoryUnit entity) {
			client.InventoryUnitUpdate(entity);
		}
	}
}
