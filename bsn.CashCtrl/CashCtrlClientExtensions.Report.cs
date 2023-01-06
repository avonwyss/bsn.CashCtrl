using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static ReportNode[] ReportTree(this CashCtrlClient that) {
			return that.Get<ListResponse<ReportNode>>("report/tree.json", null).Data;
		}
	}
}
