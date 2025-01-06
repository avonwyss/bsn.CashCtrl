using System;
using System.Collections.Generic;

using bsn.CashCtrl;

namespace CashCtrl.PathHandlers {
#warning TODO: Implement
	internal class CashCtrlReportHandler: CashCtrlContainerHandler {
		public CashCtrlReportHandler(): base("report") { }

		public override IEnumerable<CashCtrlPathHandler> GetAllChildHandlers(CashCtrlClient client) {
			throw new NotImplementedException();
		}

		public override bool TryGetChildHandler(string name, out CashCtrlPathHandler handler) {
			throw new NotImplementedException();
		}
	}
}
