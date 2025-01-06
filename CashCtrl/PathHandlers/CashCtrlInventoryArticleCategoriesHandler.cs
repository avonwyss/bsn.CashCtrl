using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlInventoryArticleCategoriesHandler: CashCtrlCollectionHandler<InventoryArticleCategory> {
		public CashCtrlInventoryArticleCategoriesHandler(): base("category") { }

		protected override CashCtrlEntityHandler<InventoryArticleCategory> GetEntityHandler(OneOf<int, InventoryArticleCategory> idOrEntity) {
			return new CashCtrlInventoryArticleCategoryHandler(idOrEntity);
		}

		protected override IEnumerable<InventoryArticleCategory> ListEntities(CashCtrlClient client) {
			return client.InventoryArticleCategoryList();
		}
	}
}
