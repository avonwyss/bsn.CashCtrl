using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlInventoryArticleCategoryHandler: CashCtrlEntityHandler<InventoryArticleCategory> {
		public CashCtrlInventoryArticleCategoryHandler(OneOf<int, InventoryArticleCategory> idOrEntity): base(idOrEntity) { }

		protected override int CreateEntity(CashCtrlClient client, InventoryArticleCategory entity) {
			return client.InventoryArticleCategoryCreate(entity);
		}

		protected override InventoryArticleCategory ReadEntity(CashCtrlClient client) {
			return client.InventoryArticleCategoryRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.InventoryArticleCategoryDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, InventoryArticleCategory entity) {
			client.InventoryArticleCategoryUpdate(entity);
		}
	}
}
