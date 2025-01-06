using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlSequenceNumberHandler: CashCtrlEntityHandler<SequenceNumber> {
		public CashCtrlSequenceNumberHandler(OneOf<int, SequenceNumber> idOrEntity): base(idOrEntity) { }

		protected override SequenceNumber ReadEntity(CashCtrlClient client) {
			return client.SequenceNumberRead(this.Id);
		}
	}
}
