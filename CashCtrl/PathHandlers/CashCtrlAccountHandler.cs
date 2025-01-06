using System.Collections.Generic;
using System.Linq;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlAccountHandler: CashCtrlEntityHandler<Account> {
		private readonly IReadOnlyDictionary<string, CashCtrlPathHandler> childHandlers;

		public CashCtrlAccountHandler(OneOf<int, Account> idOrEntity): base(idOrEntity) {
			this.childHandlers = CashCtrlRootHandler.CreateHandlerDictionary(new CashCtrlJournalsHandler(this.Id));
		}

		protected override Account ReadEntity(CashCtrlClient client) {
			return client.AccountRead(this.Id);
		}

		public override bool IsContainer => true;

		public override IEnumerable<CashCtrlPathHandler> GetAllChildHandlers(CashCtrlClient client) {
			return this.childHandlers.Values;
		}

		public override bool TryGetChildHandler(string name, out CashCtrlPathHandler handler) {
			return this.childHandlers.TryGetValue(name, out handler);
		}
	}
}
