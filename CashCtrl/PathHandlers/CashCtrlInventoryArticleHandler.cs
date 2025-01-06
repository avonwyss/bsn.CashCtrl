using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlInventoryArticleHandler: CashCtrlEntityHandler<InventoryArticle> {
		public CashCtrlInventoryArticleHandler(OneOf<int, InventoryArticle> idOrEntity): base(idOrEntity) { }

		protected override InventoryArticle ReadEntity(CashCtrlClient client) {
			return client.InventoryArticleRead(this.Id);
		}
	}
}
