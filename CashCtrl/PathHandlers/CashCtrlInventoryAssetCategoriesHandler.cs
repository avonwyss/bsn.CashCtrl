using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlInventoryAssetCategoriesHandler: CashCtrlCollectionHandler<InventoryAssetCategory> {
		public CashCtrlInventoryAssetCategoriesHandler(): base("category") { }

		protected override CashCtrlEntityHandler<InventoryAssetCategory> GetEntityHandler(OneOf<int, InventoryAssetCategory> idOrEntity) {
			return new CashCtrlInventoryAssetCategoryHandler(idOrEntity);
		}

		protected override IEnumerable<InventoryAssetCategory> ListEntities(CashCtrlClient client) {
			return client.InventoryAssetCategoryList();
		}
	}
}
