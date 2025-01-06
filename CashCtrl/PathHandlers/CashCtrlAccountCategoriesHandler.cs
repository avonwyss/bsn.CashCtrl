using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlAccountCategoriesHandler: CashCtrlCollectionHandler<AccountCategory> {
		public CashCtrlAccountCategoriesHandler(): base("category") { }

		protected override CashCtrlEntityHandler<AccountCategory> GetEntityHandler(OneOf<int, AccountCategory> idOrEntity) {
			return new CashCtrlAccountCategoryHandler(idOrEntity);
		}

		protected override IEnumerable<AccountCategory> ListEntities(CashCtrlClient client) {
			return client.AccountCategoryList();
		}
	}
}
