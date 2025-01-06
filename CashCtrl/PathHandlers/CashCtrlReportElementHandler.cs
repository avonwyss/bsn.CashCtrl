using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlReportElementHandler: CashCtrlEntityHandler<ReportElement> {
		public CashCtrlReportElementHandler(OneOf<int, ReportElement> idOrEntity): base(idOrEntity) { }

		protected override ReportElement ReadEntity(CashCtrlClient client) {
			return client.ReportElementRead(this.Id);
		}
	}
}
