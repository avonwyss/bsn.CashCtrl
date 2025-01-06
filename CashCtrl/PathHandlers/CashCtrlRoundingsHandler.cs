using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlRoundingsHandler: CashCtrlCollectionHandler<RoundingItem> {
		public CashCtrlRoundingsHandler(): base("rounding") { }

		protected override CashCtrlEntityHandler<RoundingItem> GetEntityHandler(OneOf<int, RoundingItem> idOrEntity) {
			return new CashCtrlRoundingHandler(idOrEntity);
		}

		protected override IEnumerable<RoundingItem> ListEntities(CashCtrlClient client) {
			return client.RoundingList();
		}
	}
}
