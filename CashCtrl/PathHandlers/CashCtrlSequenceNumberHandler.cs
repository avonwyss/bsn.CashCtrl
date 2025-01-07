using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlSequenceNumberHandler: CashCtrlEntityHandler<SequenceNumber> {
		public CashCtrlSequenceNumberHandler(OneOf<int, SequenceNumber> idOrEntity): base(idOrEntity) { }

		protected override void CreateEntity(CashCtrlClient client, SequenceNumber entity) {
			client.SequenceNumberCreate(entity);
		}

		protected override SequenceNumber ReadEntity(CashCtrlClient client) {
			return client.SequenceNumberRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.SequenceNumberDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, SequenceNumber entity) {
			client.SequenceNumberUpdate(entity);
		}
	}
}
