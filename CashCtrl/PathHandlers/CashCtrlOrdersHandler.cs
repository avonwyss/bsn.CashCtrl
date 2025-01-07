using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlOrdersHandler: CashCtrlCollectionHandler<Order, OrderQuery> {
		public CashCtrlOrdersHandler(): base("order",
				new CashCtrlOrderTemplatesHandler(),
				new CashCtrlOrderCategoriesHandler()) { }

		protected override CashCtrlEntityHandler<Order> GetEntityHandler(OneOf<int, Order> idOrEntity) {
			return new CashCtrlOrderHandler(idOrEntity);
		}

		protected override IEnumerable<Order> ListEntities(CashCtrlClient client, OrderQuery query) {
			return client.ListPaged(CashCtrlClientExtensions.OrderList, query);
		}
	}
}
