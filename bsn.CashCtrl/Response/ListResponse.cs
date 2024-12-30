using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace bsn.CashCtrl.Response {
	public class ListResponse<T> {
		public int Total {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public T[] Data {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		[JsonProperty(NullValueHandling = NullValueHandling.Include)]
		public JObject Summary {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		[JsonProperty(NullValueHandling = NullValueHandling.Include)]
		public JObject Properties {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}
	}
}
