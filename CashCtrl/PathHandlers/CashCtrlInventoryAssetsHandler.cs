using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlInventoryAssetsHandler: CashCtrlCollectionHandler<InventoryAsset, InventoryAssetQuery> {
		public CashCtrlInventoryAssetsHandler(): base("asset",
				new CashCtrlInventoryAssetCategoriesHandler()) { }

		protected override CashCtrlEntityHandler<InventoryAsset> GetEntityHandler(OneOf<int, InventoryAsset> idOrEntity) {
			return new CashCtrlInventoryAssetHandler(idOrEntity);
		}

		protected override IEnumerable<InventoryAsset> ListEntities(CashCtrlClient client, InventoryAssetQuery query) {
			return client.ListPaged(CashCtrlClientExtensions.InventoryAssetList, query);
		}
	}
}
