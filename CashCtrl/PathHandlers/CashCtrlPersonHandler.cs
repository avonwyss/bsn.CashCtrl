using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlPersonHandler: CashCtrlEntityHandler<Person> {
		public CashCtrlPersonHandler(OneOf<int, Person> idOrEntity): base(idOrEntity) { }

		protected override Person ReadEntity(CashCtrlClient client) {
			return client.PersonRead(this.Id);
		}
	}
}
