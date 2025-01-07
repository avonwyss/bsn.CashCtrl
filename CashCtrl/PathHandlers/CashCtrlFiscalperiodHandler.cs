using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlFiscalperiodHandler: CashCtrlEntityHandler<Fiscalperiod> {
		public CashCtrlFiscalperiodHandler(OneOf<int, Fiscalperiod> idOrEntity): base(idOrEntity) { }

		protected override void CreateEntity(CashCtrlClient client, Fiscalperiod entity) {
			client.FiscalperiodCreate(entity);
		}

		protected override Fiscalperiod ReadEntity(CashCtrlClient client) {
			return client.FiscalperiodRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.FiscalperiodDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, Fiscalperiod entity) {
			client.FiscalperiodUpdate(entity);
		}
	}
}
