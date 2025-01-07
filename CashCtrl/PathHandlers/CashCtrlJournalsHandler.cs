using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlJournalsHandler: CashCtrlCollectionHandler<Journal, JournalQuery> {
		public CashCtrlJournalsHandler(int? accountId = default): base("journal",
				new CashCtrlJournalImportHandler()
		) {
			this.AccountId = accountId;
		}

		public int? AccountId {
			get;
		}

		protected override CashCtrlEntityHandler<Journal> GetEntityHandler(OneOf<int, Journal> idOrEntity) {
			return new CashCtrlJournalHandler(idOrEntity);
		}

		protected override IEnumerable<Journal> ListEntities(CashCtrlClient client, JournalQuery query) {
			if (this.AccountId.HasValue) {
				query ??= new();
				query.AccountId = this.AccountId;
			}
			return client.ListPaged(CashCtrlClientExtensions.JournalList, query);
		}
	}
}
