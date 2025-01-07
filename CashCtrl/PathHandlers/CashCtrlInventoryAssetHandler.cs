using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlInventoryAssetHandler: CashCtrlEntityHandler<InventoryAsset> {
		public CashCtrlInventoryAssetHandler(OneOf<int, InventoryAsset> idOrEntity): base(idOrEntity) { }

		protected override void CreateEntity(CashCtrlClient client, InventoryAsset entity) {
			client.InventoryAssetCreate(entity);
		}

		protected override InventoryAsset ReadEntity(CashCtrlClient client) {
			return client.InventoryAssetRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.InventoryAssetDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, InventoryAsset entity) {
			client.InventoryAssetUpdate(entity);
		}
	}
}
