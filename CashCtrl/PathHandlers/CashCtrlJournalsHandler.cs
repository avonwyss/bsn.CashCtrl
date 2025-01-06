using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlJournalsHandler: CashCtrlCollectionHandler<Journal> {
		public int? AccountId {
			get;
		}

		public CashCtrlJournalsHandler(int? accountId = default): base("journal",
				new CashCtrlJournalImportHandler()
		) {
			this.AccountId = accountId;
		}

		protected override CashCtrlEntityHandler<Journal> GetEntityHandler(OneOf<int, Journal> idOrEntity) {
			return new CashCtrlJournalHandler(idOrEntity);
		}

		protected override IEnumerable<Journal> ListEntities(CashCtrlClient client) {
			return client.ListPaged<Journal, JournalQuery>(CashCtrlClientExtensions.JournalList, new() {
					AccountId = this.AccountId
			});
		}
	}
}
