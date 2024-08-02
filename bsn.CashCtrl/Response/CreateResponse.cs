using System;

namespace bsn.CashCtrl.Response {
	public class CreateResponse: UpdateResponse {
		public int InsertId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)] set;
		}

		public int GetInsertIdOrThrow() {
			this.EnsureSuccess();
			return this.InsertId;
		}
	}
}
