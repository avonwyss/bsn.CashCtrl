using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlInventoryArticleHandler: CashCtrlEntityHandler<InventoryArticle> {
		public CashCtrlInventoryArticleHandler(OneOf<int, InventoryArticle> idOrEntity): base(idOrEntity) { }

		protected override int CreateEntity(CashCtrlClient client, InventoryArticle entity) {
			return client.InventoryArticleCreate(entity);
		}

		protected override InventoryArticle ReadEntity(CashCtrlClient client) {
			return client.InventoryArticleRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.InventoryArticleDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, InventoryArticle entity) {
			client.InventoryArticleUpdate(entity);
		}
	}
}
