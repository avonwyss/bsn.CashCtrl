using System;

using Newtonsoft.Json;

namespace bsn.CashCtrl.Response {
	public class ReadResponse<T>: ActionResponse {
		[JsonProperty(NullValueHandling = NullValueHandling.Include)]
		public T Data {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public T GetDataOrThrow() {
			this.EnsureSuccess();
			return this.Data;
		}
	}
}
