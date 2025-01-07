using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlInventoryArticleCategoriesHandler: CashCtrlCollectionHandler<InventoryArticleCategory> {
		public CashCtrlInventoryArticleCategoriesHandler(): base("category") { }

		protected override CashCtrlEntityHandler<InventoryArticleCategory> GetEntityHandler(OneOf<int, InventoryArticleCategory> idOrEntity) {
			return new CashCtrlInventoryArticleCategoryHandler(idOrEntity);
		}

		protected override IEnumerable<InventoryArticleCategory> ListEntities(CashCtrlClient client, QueryBase query) {
			return client.InventoryArticleCategoryList();
		}
	}
}
