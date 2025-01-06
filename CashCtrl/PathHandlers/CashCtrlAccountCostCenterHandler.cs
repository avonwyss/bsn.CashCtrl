using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlAccountCostCenterHandler: CashCtrlEntityHandler<AccountCostCenter> {
		public CashCtrlAccountCostCenterHandler(OneOf<int, AccountCostCenter> idOrEntity): base(idOrEntity) { }

		protected override AccountCostCenter ReadEntity(CashCtrlClient client) {
			return client.AccountCostCenterRead(this.Id);
		}
	}
}
