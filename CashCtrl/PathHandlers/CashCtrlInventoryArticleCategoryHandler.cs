using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlInventoryArticleCategoryHandler: CashCtrlEntityHandler<InventoryArticleCategory> {
		public CashCtrlInventoryArticleCategoryHandler(OneOf<int, InventoryArticleCategory> idOrEntity): base(idOrEntity) { }

		protected override InventoryArticleCategory ReadEntity(CashCtrlClient client) {
			return client.InventoryArticleCategoryRead(this.Id);
		}
	}
}
