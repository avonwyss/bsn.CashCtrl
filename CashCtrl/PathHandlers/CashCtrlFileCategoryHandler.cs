using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlFileCategoryHandler: CashCtrlEntityHandler<FileCategory> {
		public CashCtrlFileCategoryHandler(OneOf<int, FileCategory> idOrEntity): base(idOrEntity) { }

		protected override FileCategory ReadEntity(CashCtrlClient client) {
			return client.FileCategoryRead(this.Id);
		}
	}
}
