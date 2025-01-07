using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlAccountCostCentersHandler: CashCtrlCollectionHandler<AccountCostCenter, AccountCostCenterQuery> {
		public CashCtrlAccountCostCentersHandler(): base("costcenter",
				new CashCtrlAccountCostCenterCategoriesHandler()) { }

		protected override CashCtrlEntityHandler<AccountCostCenter> GetEntityHandler(OneOf<int, AccountCostCenter> idOrEntity) {
			return new CashCtrlAccountCostCenterHandler(idOrEntity);
		}

		protected override IEnumerable<AccountCostCenter> ListEntities(CashCtrlClient client, AccountCostCenterQuery query) {
			return client.AccountCostCenterList(query);
		}
	}
}
