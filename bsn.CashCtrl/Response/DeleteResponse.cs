using System;

namespace bsn.CashCtrl.Response {
	public class DeleteResponse: ActionResponse {
		public string Message {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)] set;
		}

		public override void EnsureSuccess() {
			if (!this.Success) {
				throw new CashCtrlApiException(this.Message ?? this.ErrorMessage);
			}
		}
	}
}
