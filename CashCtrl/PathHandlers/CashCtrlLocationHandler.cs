using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlLocationHandler: CashCtrlEntityHandler<Location> {
		public CashCtrlLocationHandler(OneOf<int, Location> idOrEntity): base(idOrEntity) { }

		protected override Location ReadEntity(CashCtrlClient client) {
			return client.LocationRead(this.Id);
		}
	}
}
