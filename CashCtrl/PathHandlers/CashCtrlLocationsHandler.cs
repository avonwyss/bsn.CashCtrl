using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlLocationsHandler: CashCtrlCollectionHandler<Location> {
		public CashCtrlLocationsHandler(): base("location") { }

		protected override CashCtrlEntityHandler<Location> GetEntityHandler(OneOf<int, Location> idOrEntity) {
			return new CashCtrlLocationHandler(idOrEntity);
		}

		protected override IEnumerable<Location> ListEntities(CashCtrlClient client) {
			return client.LocationList();
		}
	}
}
