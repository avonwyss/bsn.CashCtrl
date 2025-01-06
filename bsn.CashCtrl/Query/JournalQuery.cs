using System.Collections.Generic;

namespace bsn.CashCtrl.Query {
	public class JournalQuery: QueryBase {
		public int? AccountId {
			get;
			set;
		}

		public int? FiscalperiodId {
			get;
			set;
		}

		public bool? OnlyCollective {
			get;
			set;
		}

		public bool? OnlyCostCenters {
			get;
			set;
		}

		public bool? OnlyImported {
			get;
			set;
		}

		public bool? OnlyManual {
			get;
			set;
		}

		public bool? OnlyUntaxed {
			get;
			set;
		}

		protected override IEnumerable<KeyValuePair<string, object>> ToParametersInternal() {
			yield return new("accountId", this.AccountId);
			yield return new("fiscalPeriodId", this.FiscalperiodId);
			yield return new("onlyCollective", this.OnlyCollective);
			yield return new("onlyCostCenters", this.OnlyCostCenters);
			yield return new("onlyImported", this.OnlyImported);
			yield return new("onlyManual", this.OnlyManual);
			yield return new("onlyUntaxed", this.OnlyUntaxed);
		}
	}
}
