using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlCustomFieldGroupHandler: CashCtrlEntityHandler<CustomFieldGroup> {
		public CashCtrlCustomFieldGroupHandler(OneOf<int, CustomFieldGroup> idOrEntity): base(idOrEntity) { }

		protected override void CreateEntity(CashCtrlClient client, CustomFieldGroup entity) {
			client.CustomFieldGroupCreate(entity);
		}

		protected override CustomFieldGroup ReadEntity(CashCtrlClient client) {
			return client.CustomFieldGroupRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.CustomFieldGroupDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, CustomFieldGroup entity) {
			client.CustomFieldGroupUpdate(entity);
		}
	}
}
