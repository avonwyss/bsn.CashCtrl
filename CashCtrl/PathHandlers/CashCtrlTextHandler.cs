using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlTextHandler: CashCtrlEntityHandler<Text> {
		public CashCtrlTextHandler(OneOf<int, Text> idOrEntity): base(idOrEntity) { }

		protected override Text ReadEntity(CashCtrlClient client) {
			return client.TextRead(this.Id);
		}
	}
}
