using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlCurrencyHandler: CashCtrlEntityHandler<Currency> {
		public CashCtrlCurrencyHandler(OneOf<int, Currency> idOrEntity): base(idOrEntity) { }

		protected override Currency ReadEntity(CashCtrlClient client) {
			return client.CurrencyRead(this.Id);
		}
	}
}
