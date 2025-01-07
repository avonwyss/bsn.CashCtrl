using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlInventoryUnitsHandler: CashCtrlCollectionHandler<InventoryUnit> {
		public CashCtrlInventoryUnitsHandler(): base("unit") { }

		protected override CashCtrlEntityHandler<InventoryUnit> GetEntityHandler(OneOf<int, InventoryUnit> idOrEntity) {
			return new CashCtrlInventoryUnitHandler(idOrEntity);
		}

		protected override IEnumerable<InventoryUnit> ListEntities(CashCtrlClient client, QueryBase query) {
			return client.InventoryUnitList();
		}
	}
}
