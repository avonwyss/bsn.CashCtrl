using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlAccountCostCenterCategoryHandler: CashCtrlEntityHandler<AccountCostCenterCategory> {
		public CashCtrlAccountCostCenterCategoryHandler(OneOf<int, AccountCostCenterCategory> idOrEntity): base(idOrEntity) { }

		protected override void CreateEntity(CashCtrlClient client, AccountCostCenterCategory entity) {
			client.AccountCostCenterCategoryCreate(entity);
		}

		protected override AccountCostCenterCategory ReadEntity(CashCtrlClient client) {
			return client.AccountCostCenterCategoryRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.AccountCostCenterCategoryDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, AccountCostCenterCategory entity) {
			client.AccountCostCenterCategoryUpdate(entity);
		}
	}
}
