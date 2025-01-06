using System.Management.Automation;

using bsn.CashCtrl;

namespace CashCtrl {
	internal class CashCtrlPSDriveInfo: PSDriveInfo {
		public CashCtrlClient Client {
			get;
		}

		public CashCtrlPSDriveInfo(PSDriveInfo driveInfo, CashCtrlClient client): base(driveInfo) {
			this.Client = client;
		}
	}
}