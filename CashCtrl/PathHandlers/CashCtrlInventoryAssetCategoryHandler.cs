using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlInventoryAssetCategoryHandler: CashCtrlEntityHandler<InventoryAssetCategory> {
		public CashCtrlInventoryAssetCategoryHandler(OneOf<int, InventoryAssetCategory> idOrEntity): base(idOrEntity) { }

		protected override InventoryAssetCategory ReadEntity(CashCtrlClient client) {
			return client.InventoryAssetCategoryRead(this.Id);
		}
	}
}
