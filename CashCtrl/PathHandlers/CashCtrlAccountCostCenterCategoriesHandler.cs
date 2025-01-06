using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlAccountCostCenterCategoriesHandler: CashCtrlCollectionHandler<AccountCostCenterCategory> {
		public CashCtrlAccountCostCenterCategoriesHandler(): base("category") { }

		protected override CashCtrlEntityHandler<AccountCostCenterCategory> GetEntityHandler(OneOf<int, AccountCostCenterCategory> idOrEntity) {
			return new CashCtrlAccountCostCenterCategoryHandler(idOrEntity);
		}

		protected override IEnumerable<AccountCostCenterCategory> ListEntities(CashCtrlClient client) {
			return client.AccountCostCenterCategoryList();
		}
	}
}
