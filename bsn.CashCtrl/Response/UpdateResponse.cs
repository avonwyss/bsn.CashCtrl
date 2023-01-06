using System;

namespace bsn.CashCtrl.Response {
	public class UpdateResponse: ActionResponse {
		public class Error {
			public string Field {
				get;
				[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)] set;
			}

			public string Message {
				get;
				[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)] set;
			}
		}

		public Error[] Errors {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)] set;
		}

		public override void EnsureSuccess() {
			if (!Success) {
				throw new CashCtrlApiException(ErrorMessage, Errors);
			}
		}
	}
}