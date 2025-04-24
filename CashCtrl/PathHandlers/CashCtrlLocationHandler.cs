using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlLocationHandler: CashCtrlEntityHandler<Location> {
		public CashCtrlLocationHandler(OneOf<int, Location> idOrEntity): base(idOrEntity) { }

		protected override int CreateEntity(CashCtrlClient client, Location entity) {
			return client.LocationCreate(entity);
		}

		protected override Location ReadEntity(CashCtrlClient client) {
			return client.LocationRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.LocationDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, Location entity) {
			client.LocationUpdate(entity);
		}
	}
}
