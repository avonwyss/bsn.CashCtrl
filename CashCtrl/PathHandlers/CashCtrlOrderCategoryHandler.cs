using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlOrderCategoryHandler: CashCtrlEntityHandler<OrderCategory> {
		public CashCtrlOrderCategoryHandler(OneOf<int, OrderCategory> idOrEntity): base(idOrEntity) { }

		protected override void CreateEntity(CashCtrlClient client, OrderCategory entity) {
			client.OrderCategoryCreate(entity);
		}

		protected override OrderCategory ReadEntity(CashCtrlClient client) {
			return client.OrderCategoryRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.OrderCategoryDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, OrderCategory entity) {
			client.OrderCategoryUpdate(entity);
		}
	}
}
