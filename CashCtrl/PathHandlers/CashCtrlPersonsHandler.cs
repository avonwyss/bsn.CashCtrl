using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlPersonsHandler: CashCtrlCollectionHandler<Person, PersonQuery> {
		public CashCtrlPersonsHandler(): base("person") { }

		protected override CashCtrlEntityHandler<Person> GetEntityHandler(OneOf<int, Person> idOrEntity) {
			return new CashCtrlPersonHandler(idOrEntity);
		}

		protected override IEnumerable<Person> ListEntities(CashCtrlClient client, PersonQuery query) {
			return client.ListPaged(CashCtrlClientExtensions.PersonList, query);
		}
	}
}
