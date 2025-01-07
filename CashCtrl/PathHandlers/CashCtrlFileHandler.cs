using System;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlFileHandler: CashCtrlEntityHandler<File> {
		public CashCtrlFileHandler(OneOf<int, File> idOrEntity): base(idOrEntity) { }

		protected override void CreateEntity(CashCtrlClient client, File entity) {
			throw new NotImplementedException();
#warning client.FileCreate(entity);
		}

		protected override File ReadEntity(CashCtrlClient client) {
			return client.FileRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.FileDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, File entity) {
			client.FileUpdate(entity);
		}
	}
}
