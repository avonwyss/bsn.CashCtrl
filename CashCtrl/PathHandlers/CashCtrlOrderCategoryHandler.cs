using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlOrderCategoryHandler: CashCtrlEntityHandler<OrderCategory> {
		public CashCtrlOrderCategoryHandler(OneOf<int, OrderCategory> idOrEntity): base(idOrEntity) { }

		protected override OrderCategory ReadEntity(CashCtrlClient client) {
			return client.OrderCategoryRead(this.Id);
		}
	}
}
