using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlSequenceNumbersHandler: CashCtrlCollectionHandler<SequenceNumber> {
		public CashCtrlSequenceNumbersHandler(): base("sequencenumber") { }

		protected override CashCtrlEntityHandler<SequenceNumber> GetEntityHandler(OneOf<int, SequenceNumber> idOrEntity) {
			return new CashCtrlSequenceNumberHandler(idOrEntity);
		}

		protected override IEnumerable<SequenceNumber> ListEntities(CashCtrlClient client, QueryBase query) {
			return client.SequenceNumberList();
		}
	}
}
