using System;

using bsn.CashCtrl.Entities;

namespace bsn.CashCtrl.Response {
	public class PrepareFileResponse: ActionResponse {
		public PreparedFile[] Data {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public PreparedFile[] GetDataOrThrow() {
			this.EnsureSuccess();
			return this.Data;
		}
	}
}
