using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlInventoryUnitsHandler: CashCtrlCollectionHandler<InventoryUnit> {
		public CashCtrlInventoryUnitsHandler(): base("unit") { }

		protected override CashCtrlEntityHandler<InventoryUnit> GetEntityHandler(OneOf<int, InventoryUnit> idOrEntity) {
			return new CashCtrlInventoryUnitHandler(idOrEntity);
		}

		protected override IEnumerable<InventoryUnit> ListEntities(CashCtrlClient client) {
			return client.InventoryUnitList();
		}
	}
}
