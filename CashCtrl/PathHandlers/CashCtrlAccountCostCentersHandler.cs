using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlAccountCostCentersHandler: CashCtrlCollectionHandler<AccountCostCenter> {
		public CashCtrlAccountCostCentersHandler(): base("costcenter",
				new CashCtrlAccountCostCenterCategoriesHandler()) { }

		protected override CashCtrlEntityHandler<AccountCostCenter> GetEntityHandler(OneOf<int, AccountCostCenter> idOrEntity) {
			return new CashCtrlAccountCostCenterHandler(idOrEntity);
		}

		protected override IEnumerable<AccountCostCenter> ListEntities(CashCtrlClient client) {
			return client.AccountCostCenterList();
		}
	}
}
