using System.Collections.Generic;
using System.ComponentModel;

namespace bsn.CashCtrl.Query {
	public class AccountCostCenterQuery: FilterQuery {
		[Description("The ID of the fiscal period, from which we retrieve the balances. Leave empty to use the current fiscal period.")]
		public int? FiscalperiodId {
			get;
			set;
		}

		[Description("Flag to only include active cost centers. Defaults to false.")]
		public bool? OnlyActive {
			get;
			set;
		}

		public override IEnumerable<KeyValuePair<string, object>> ToParameters() {
			foreach (var parameter in base.ToParameters()) {
				yield return parameter;
			}
			yield return new("fiscalPeriodId", this.FiscalperiodId);
			yield return new("onlyActive", this.OnlyActive);
		}
	}
}
