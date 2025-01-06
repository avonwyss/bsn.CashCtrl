using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlAccountCostCenterCategoryHandler: CashCtrlEntityHandler<AccountCostCenterCategory> {
		public CashCtrlAccountCostCenterCategoryHandler(OneOf<int, AccountCostCenterCategory> idOrEntity): base(idOrEntity) { }

		protected override AccountCostCenterCategory ReadEntity(CashCtrlClient client) {
			return client.AccountCostCenterCategoryRead(this.Id);
		}
	}
}
