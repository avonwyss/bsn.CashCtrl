using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace bsn.CashCtrl.Query {
	public class CashCtrlFilter: IApiSerializable {
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public CashCtrlComparison? Comparison {
			get;
			set;
		}

		public string Field {
			get;
			set;
		}

		public object Value {
			get;
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			yield return new("field", this.Field);
			if (this.Comparison.HasValue) {
				yield return new("comparison", this.Comparison.Value);
			}
			yield return new("value", this.Value);
		}
	}
}
