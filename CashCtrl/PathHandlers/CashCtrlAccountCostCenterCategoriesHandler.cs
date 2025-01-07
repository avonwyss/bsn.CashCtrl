using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlAccountCostCenterCategoriesHandler: CashCtrlCollectionHandler<AccountCostCenterCategory> {
		public CashCtrlAccountCostCenterCategoriesHandler(): base("category") { }

		protected override CashCtrlEntityHandler<AccountCostCenterCategory> GetEntityHandler(OneOf<int, AccountCostCenterCategory> idOrEntity) {
			return new CashCtrlAccountCostCenterCategoryHandler(idOrEntity);
		}

		protected override IEnumerable<AccountCostCenterCategory> ListEntities(CashCtrlClient client, QueryBase query) {
			return client.AccountCostCenterCategoryList();
		}
	}
}
