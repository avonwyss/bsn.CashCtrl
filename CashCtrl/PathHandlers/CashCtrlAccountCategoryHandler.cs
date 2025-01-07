using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlAccountCategoryHandler: CashCtrlEntityHandler<AccountCategory> {
		public CashCtrlAccountCategoryHandler(OneOf<int, AccountCategory> idOrEntity): base(idOrEntity) { }

		protected override void CreateEntity(CashCtrlClient client, AccountCategory entity) {
			client.AccountCategoryCreate(entity);
		}

		protected override AccountCategory ReadEntity(CashCtrlClient client) {
			return client.AccountCategoryRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.AccountCategoryDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, AccountCategory entity) {
			client.AccountCategoryUpdate(entity);
		}
	}
}
