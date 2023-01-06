using System.Collections.Generic;

namespace bsn.CashCtrl.Query {
	public class AccountQuery: QueryBase {
		public int? FiscalPeriodId {
			get;
			set;
		}

		public bool? OnlyCostCenters {
			get;
			set;
		}

		public bool? OnlyActive {
			get;
			set;
		}

		protected override IEnumerable<KeyValuePair<string, object>> ToParametersInternal() {
			yield return new("fiscalPeriodId", FiscalPeriodId);
			yield return new("onlyCostCenters", OnlyCostCenters);
			yield return new("onlyActive", OnlyActive);
		}
	}
}