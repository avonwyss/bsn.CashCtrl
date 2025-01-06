using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlJournalHandler: CashCtrlEntityHandler<Journal> {
		public CashCtrlJournalHandler(OneOf<int, Journal> idOrEntity): base(idOrEntity) { }

		protected override Journal ReadEntity(CashCtrlClient client) {
			return client.JournalRead(this.Id);
		}
	}
}
