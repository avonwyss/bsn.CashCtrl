using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlOrderTemplateHandler: CashCtrlEntityHandler<OrderTemplate> {
		public CashCtrlOrderTemplateHandler(OneOf<int, OrderTemplate> idOrEntity): base(idOrEntity) { }

		protected override void CreateEntity(CashCtrlClient client, OrderTemplate entity) {
			client.OrderTemplateCreate(entity);
		}

		protected override OrderTemplate ReadEntity(CashCtrlClient client) {
			return client.OrderTemplateRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.OrderTemplateDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, OrderTemplate entity) {
			client.OrderTemplateUpdate(entity);
		}
	}
}
