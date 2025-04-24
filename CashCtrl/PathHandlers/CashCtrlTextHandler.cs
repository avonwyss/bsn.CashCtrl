using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlTextHandler: CashCtrlEntityHandler<Text> {
		public CashCtrlTextHandler(OneOf<int, Text> idOrEntity): base(idOrEntity) { }

		protected override int CreateEntity(CashCtrlClient client, Text entity) {
			return client.TextCreate(entity);
		}

		protected override Text ReadEntity(CashCtrlClient client) {
			return client.TextRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.TextDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, Text entity) {
			client.TextUpdate(entity);
		}
	}
}
