using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlCustomFieldGroupHandler: CashCtrlEntityHandler<CustomFieldGroup> {
		public CashCtrlCustomFieldGroupHandler(OneOf<int, CustomFieldGroup> idOrEntity): base(idOrEntity) { }

		protected override CustomFieldGroup ReadEntity(CashCtrlClient client) {
			return client.CustomFieldGroupRead(this.Id);
		}
	}
}
