using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlCustomFieldHandler: CashCtrlEntityHandler<CustomField> {
		public CashCtrlCustomFieldHandler(OneOf<int, CustomField> idOrEntity): base(idOrEntity) { }

		protected override void CreateEntity(CashCtrlClient client, CustomField entity) {
			client.CustomFieldCreate(entity);
		}

		protected override CustomField ReadEntity(CashCtrlClient client) {
			return client.CustomFieldRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.CustomFieldDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, CustomField entity) {
			client.CustomFieldUpdate(entity);
		}
	}
}
