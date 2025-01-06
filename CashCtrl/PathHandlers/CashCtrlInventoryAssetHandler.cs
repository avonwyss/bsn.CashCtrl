using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlInventoryAssetHandler: CashCtrlEntityHandler<InventoryAsset> {
		public CashCtrlInventoryAssetHandler(OneOf<int, InventoryAsset> idOrEntity): base(idOrEntity) { }

		protected override InventoryAsset ReadEntity(CashCtrlClient client) {
			return client.InventoryAssetRead(this.Id);
		}
	}
}
