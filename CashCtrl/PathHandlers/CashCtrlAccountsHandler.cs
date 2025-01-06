using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlAccountsHandler: CashCtrlCollectionHandler<Account> {
		public CashCtrlAccountsHandler(): base("account",
				new CashCtrlAccountCategoriesHandler(),
				new CashCtrlAccountCostCentersHandler()) { }

		protected override CashCtrlEntityHandler<Account> GetEntityHandler(OneOf<int, Account> idOrEntity) {
			return new CashCtrlAccountHandler(idOrEntity);
		}

		protected override IEnumerable<Account> ListEntities(CashCtrlClient client) {
			return client.AccountList();
		}
	}
}
