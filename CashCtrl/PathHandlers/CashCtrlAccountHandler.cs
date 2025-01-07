using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlAccountHandler: CashCtrlEntityHandler<Account> {
		private readonly IReadOnlyDictionary<string, CashCtrlPathHandler> childHandlers;

		public CashCtrlAccountHandler(OneOf<int, Account> idOrEntity): base(idOrEntity) {
			this.childHandlers = CashCtrlRootHandler.CreateHandlerDictionary(new CashCtrlJournalsHandler(this.Id));
		}

		public override bool IsContainer => true;

		protected override void CreateEntity(CashCtrlClient client, Account entity) {
			client.AccountCreate(entity);
		}

		public override IEnumerable<CashCtrlPathHandler> GetChildHandlers(CashCtrlClient client, object parameters) {
			return this.childHandlers.Values;
		}

		protected override Account ReadEntity(CashCtrlClient client) {
			return client.AccountRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.AccountDelete(this.Id);
		}

		public override bool TryGetChildHandler(string name, out CashCtrlPathHandler handler) {
			return this.childHandlers.TryGetValue(name, out handler);
		}

		protected override void UpdateEntity(CashCtrlClient client, Account entity) {
			client.AccountUpdate(entity);
		}
	}
}
