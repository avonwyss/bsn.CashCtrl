using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlOrderTemplatesHandler: CashCtrlCollectionHandler<OrderTemplate> {
		public CashCtrlOrderTemplatesHandler(): base("template") { }

		protected override CashCtrlEntityHandler<OrderTemplate> GetEntityHandler(OneOf<int, OrderTemplate> idOrEntity) {
			return new CashCtrlOrderTemplateHandler(idOrEntity);
		}

		protected override IEnumerable<OrderTemplate> ListEntities(CashCtrlClient client, QueryBase query) {
			return client.OrderTemplateList();
		}
	}
}
