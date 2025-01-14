using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlFilesHandler: CashCtrlCollectionHandler<File, FileQuery> {
		public CashCtrlFilesHandler(): base("file",
				new CashCtrlFileCategoriesHandler()) { }

		protected override CashCtrlEntityHandler<File> GetEntityHandler(OneOf<int, File> idOrEntity) {
			return new CashCtrlFileHandler(idOrEntity);
		}

		protected override IEnumerable<File> ListEntities(CashCtrlClient client, FileQuery query) {
			return client.ListPaged(CashCtrlClientExtensions.FileList, query);
		}
	}
}
