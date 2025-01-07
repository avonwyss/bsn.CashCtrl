using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlInventoryArticlesHandler: CashCtrlCollectionHandler<InventoryArticle, InventoryArticleQuery> {
		public CashCtrlInventoryArticlesHandler(): base("article",
				new CashCtrlInventoryArticleCategoriesHandler(),
				new CashCtrlInventoryArticleImportHandler()) { }

		protected override CashCtrlEntityHandler<InventoryArticle> GetEntityHandler(OneOf<int, InventoryArticle> idOrEntity) {
			return new CashCtrlInventoryArticleHandler(idOrEntity);
		}

		protected override IEnumerable<InventoryArticle> ListEntities(CashCtrlClient client, InventoryArticleQuery query) {
			return client.ListPaged(CashCtrlClientExtensions.InventoryArticleList, query);
		}
	}
}
