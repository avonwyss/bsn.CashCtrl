using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlAccountCostCenterHandler: CashCtrlEntityHandler<AccountCostCenter> {
		public CashCtrlAccountCostCenterHandler(OneOf<int, AccountCostCenter> idOrEntity): base(idOrEntity) { }

		protected override int CreateEntity(CashCtrlClient client, AccountCostCenter entity) {
			return client.AccountCostCenterCreate(entity);
		}

		protected override AccountCostCenter ReadEntity(CashCtrlClient client) {
			return client.AccountCostCenterRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.AccountCostCenterDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, AccountCostCenter entity) {
			client.AccountCostCenterUpdate(entity);
		}
	}
}
