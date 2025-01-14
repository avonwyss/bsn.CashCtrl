using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlTaxesHandler: CashCtrlCollectionHandler<Tax> {
		public CashCtrlTaxesHandler(): base("tax") { }

		protected override CashCtrlEntityHandler<Tax> GetEntityHandler(OneOf<int, Tax> idOrEntity) {
			return new CashCtrlTaxHandler(idOrEntity);
		}

		protected override IEnumerable<Tax> ListEntities(CashCtrlClient client, QueryBase query) {
			return client.TaxList();
		}
	}
}
