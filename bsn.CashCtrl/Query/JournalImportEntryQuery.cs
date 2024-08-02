using System.Collections.Generic;

namespace bsn.CashCtrl.Query {
	public class JournalImportEntryQuery: QueryBase {
		public bool? OnlyCostCenters {
			get;
			set;
		}

		protected override IEnumerable<KeyValuePair<string, object>> ToParametersInternal() {
			yield return new("onlyCostCenters", this.OnlyCostCenters);
		}
	}
}
