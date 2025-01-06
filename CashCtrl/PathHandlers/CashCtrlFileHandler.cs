using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlFileHandler: CashCtrlEntityHandler<File> {
		public CashCtrlFileHandler(OneOf<int, File> idOrEntity): base(idOrEntity) { }

		protected override File ReadEntity(CashCtrlClient client) {
			return client.FileRead(this.Id);
		}
	}
}
