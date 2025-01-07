using System;
using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlReportElementsHandler: CashCtrlCollectionHandler<ReportElement> {
		public CashCtrlReportElementsHandler(): base("element") { }

		protected override CashCtrlEntityHandler<ReportElement> GetEntityHandler(OneOf<int, ReportElement> idOrEntity) {
			return new CashCtrlReportElementHandler(idOrEntity);
		}

		protected override IEnumerable<ReportElement> ListEntities(CashCtrlClient client, QueryBase query) {
			throw new NotImplementedException();
		}
	}
}
