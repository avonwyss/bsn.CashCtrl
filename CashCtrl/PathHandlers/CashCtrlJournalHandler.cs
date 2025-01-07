using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlJournalHandler: CashCtrlEntityHandler<Journal> {
		public CashCtrlJournalHandler(OneOf<int, Journal> idOrEntity): base(idOrEntity) { }

		protected override void CreateEntity(CashCtrlClient client, Journal entity) {
			client.JournalCreate(entity);
		}

		protected override Journal ReadEntity(CashCtrlClient client) {
			return client.JournalRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.JournalDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, Journal entity) {
			client.JournalUpdate(entity);
		}
	}
}
