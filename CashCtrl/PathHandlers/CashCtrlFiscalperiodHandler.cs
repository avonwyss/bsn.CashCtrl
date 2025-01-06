using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlFiscalperiodHandler: CashCtrlEntityHandler<Fiscalperiod> {
		public CashCtrlFiscalperiodHandler(OneOf<int, Fiscalperiod> idOrEntity): base(idOrEntity) { }

		protected override Fiscalperiod ReadEntity(CashCtrlClient client) {
			return client.FiscalperiodRead(this.Id);
		}
	}
}
