using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlInventoryAssetCategoryHandler: CashCtrlEntityHandler<InventoryAssetCategory> {
		public CashCtrlInventoryAssetCategoryHandler(OneOf<int, InventoryAssetCategory> idOrEntity): base(idOrEntity) { }

		protected override void CreateEntity(CashCtrlClient client, InventoryAssetCategory entity) {
			client.InventoryAssetCategoryCreate(entity);
		}

		protected override InventoryAssetCategory ReadEntity(CashCtrlClient client) {
			return client.InventoryAssetCategoryRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.InventoryAssetCategoryDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, InventoryAssetCategory entity) {
			client.InventoryAssetCategoryUpdate(entity);
		}
	}
}
