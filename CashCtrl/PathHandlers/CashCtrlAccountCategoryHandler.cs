using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlAccountCategoryHandler: CashCtrlEntityHandler<AccountCategory> {
		public CashCtrlAccountCategoryHandler(OneOf<int, AccountCategory> idOrEntity): base(idOrEntity) { }

		protected override AccountCategory ReadEntity(CashCtrlClient client) {
			return client.AccountCategoryRead(this.Id);
		}
	}
}
