using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static ReportNode[] ReportTree(this CashCtrlClient that) {
			return that.Get<ListResponse<ReportNode>>("report/tree.json", null).Data;
		}

		public static async ValueTask<ReportNode[]> ReportTreeAsync(this CashCtrlClient that) {
			var response = await that.GetAsync<ListResponse<ReportNode>>("report/tree.json", null).ConfigureAwait(false);
			return response.Data;
		}
	}
}
