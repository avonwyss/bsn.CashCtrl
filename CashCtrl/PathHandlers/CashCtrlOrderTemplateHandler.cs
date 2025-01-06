using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlOrderTemplateHandler: CashCtrlEntityHandler<OrderTemplate> {
		public CashCtrlOrderTemplateHandler(OneOf<int, OrderTemplate> idOrEntity): base(idOrEntity) { }

		protected override OrderTemplate ReadEntity(CashCtrlClient client) {
			return client.OrderTemplateRead(this.Id);
		}
	}
}
