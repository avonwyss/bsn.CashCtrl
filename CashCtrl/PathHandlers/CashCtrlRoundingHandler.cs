using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlRoundingHandler: CashCtrlEntityHandler<RoundingItem> {
		public CashCtrlRoundingHandler(OneOf<int, RoundingItem> idOrEntity): base(idOrEntity) { }

		protected override RoundingItem ReadEntity(CashCtrlClient client) {
			return client.RoundingRead(this.Id);
		}
	}
}
