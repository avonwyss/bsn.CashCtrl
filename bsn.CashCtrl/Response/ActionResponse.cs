using System;

using Newtonsoft.Json;

namespace bsn.CashCtrl.Response {
	public class ActionResponse {
		public bool Success {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string ErrorMessage {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public virtual void EnsureSuccess() {
			if (!this.Success) {
				throw new InvalidOperationException(this.ErrorMessage);
			}
		}
	}
}
