using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlCustomFieldHandler: CashCtrlEntityHandler<CustomField> {
		public CashCtrlCustomFieldHandler(OneOf<int, CustomField> idOrEntity): base(idOrEntity) { }

		protected override CustomField ReadEntity(CashCtrlClient client) {
			return client.CustomFieldRead(this.Id);
		}
	}
}
