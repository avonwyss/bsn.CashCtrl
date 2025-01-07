using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlFiscalperiodsHandler: CashCtrlCollectionHandler<Fiscalperiod> {
		public CashCtrlFiscalperiodsHandler(): base("fiscalperiod",
				new CashCtrlFiscalperiodTasksHandler()) { }

		protected override CashCtrlEntityHandler<Fiscalperiod> GetEntityHandler(OneOf<int, Fiscalperiod> idOrEntity) {
			return new CashCtrlFiscalperiodHandler(idOrEntity);
		}

		protected override IEnumerable<Fiscalperiod> ListEntities(CashCtrlClient client, QueryBase query) {
			return client.FiscalperiodList();
		}
	}
}
