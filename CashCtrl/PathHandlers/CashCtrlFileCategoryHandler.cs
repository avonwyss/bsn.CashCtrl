using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlFileCategoryHandler: CashCtrlEntityHandler<FileCategory> {
		public CashCtrlFileCategoryHandler(OneOf<int, FileCategory> idOrEntity): base(idOrEntity) { }

		protected override void CreateEntity(CashCtrlClient client, FileCategory entity) {
			client.FileCategoryCreate(entity);
		}

		protected override FileCategory ReadEntity(CashCtrlClient client) {
			return client.FileCategoryRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.FileCategoryDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, FileCategory entity) {
			client.FileCategoryUpdate(entity);
		}
	}
}
