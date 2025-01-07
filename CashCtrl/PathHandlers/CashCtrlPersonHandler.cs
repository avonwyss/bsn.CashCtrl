using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlPersonHandler: CashCtrlEntityHandler<Person> {
		public CashCtrlPersonHandler(OneOf<int, Person> idOrEntity): base(idOrEntity) { }

		protected override void CreateEntity(CashCtrlClient client, Person entity) {
			client.PersonCreate(entity);
		}

		protected override Person ReadEntity(CashCtrlClient client) {
			return client.PersonRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.PersonDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, Person entity) {
			client.PersonUpdate(entity);
		}
	}
}
