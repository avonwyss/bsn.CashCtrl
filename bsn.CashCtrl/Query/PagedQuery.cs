using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace bsn.CashCtrl.Query {
	public class PagedQuery: FilterQuery {
		[Description("The number of entries to retrieve. Defaults to 100.")]
		public int? Limit {
			get;
			set;
		}

		[Description("The starting entry. Defaults to 0.")]
		public int? Start {
			get;
			set;
		}

		public override IEnumerable<KeyValuePair<string, object>> ToParameters() {
			foreach (var parameter in base.ToParameters()) {
				yield return parameter;
			}
			yield return new("start", this.Start);
			yield return new("limit", this.Limit);
		}
	}
}
