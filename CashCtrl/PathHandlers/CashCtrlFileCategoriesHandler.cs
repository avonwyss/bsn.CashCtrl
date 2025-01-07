using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlFileCategoriesHandler: CashCtrlCollectionHandler<FileCategory> {
		public CashCtrlFileCategoriesHandler(): base("category") { }

		protected override CashCtrlEntityHandler<FileCategory> GetEntityHandler(OneOf<int, FileCategory> idOrEntity) {
			return new CashCtrlFileCategoryHandler(idOrEntity);
		}

		protected override IEnumerable<FileCategory> ListEntities(CashCtrlClient client, QueryBase query) {
			return client.FileCategoryList();
		}
	}
}
