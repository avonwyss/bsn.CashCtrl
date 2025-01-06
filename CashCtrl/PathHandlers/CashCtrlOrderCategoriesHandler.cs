using System.Collections.Generic;
using System.Linq;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlOrderCategoriesHandler: CashCtrlCollectionHandler<OrderCategory> {
		public CashCtrlOrderCategoriesHandler(): base("category") { }

		protected override CashCtrlEntityHandler<OrderCategory> GetEntityHandler(OneOf<int, OrderCategory> idOrEntity) {
			return new CashCtrlOrderCategoryHandler(idOrEntity);
		}

		protected override IEnumerable<OrderCategory> ListEntities(CashCtrlClient client) {
			return client.OrderCategoryList(null, OrderType.Sales)
					.Concat(client.OrderCategoryList(null, OrderType.Purchase));
		}
	}
}
