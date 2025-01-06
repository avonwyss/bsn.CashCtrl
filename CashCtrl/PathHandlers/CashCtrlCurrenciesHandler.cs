using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlCurrenciesHandler: CashCtrlCollectionHandler<Currency> {
		public CashCtrlCurrenciesHandler(): base("currency") { }

		protected override CashCtrlEntityHandler<Currency> GetEntityHandler(OneOf<int, Currency> idOrEntity) {
			return new CashCtrlCurrencyHandler(idOrEntity);
		}

		protected override IEnumerable<Currency> ListEntities(CashCtrlClient client) {
			return client.CurrencyList();
		}
	}
}
