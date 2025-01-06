using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlTaxHandler: CashCtrlEntityHandler<Tax> {
		public CashCtrlTaxHandler(OneOf<int, Tax> idOrEntity): base(idOrEntity) { }

		protected override Tax ReadEntity(CashCtrlClient client) {
			return client.TaxRead(this.Id);
		}
	}
}
