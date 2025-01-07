using System.Collections.Generic;
using System.ComponentModel;

namespace bsn.CashCtrl.Query {
	public class AccountQuery: FilterQuery {
		[Description("The ID of the category to filter by.")]
		public int? CategoryId {
			get;
			set;
		}

		[Description("The ID of the fiscal period, from which we retrieve the balances. Leave empty to use the current fiscal period.")]
		public int? FiscalperiodId {
			get;
			set;
		}

		[Description("Flag to only include entries with cost centers. Defaults to false.")]
		public bool? OnlyCostCenters {
			get;
			set;
		}

		[Description("Flag to only include active accounts. Defaults to false.")]
		public bool? OnlyActive {
			get;
			set;
		}

		public override IEnumerable<KeyValuePair<string, object>> ToParameters() {
			foreach (var parameter in base.ToParameters()) {
				yield return parameter;
			}
			yield return new("categoryId", this.CategoryId);
			yield return new("fiscalPeriodId", this.FiscalperiodId);
			yield return new("onlyCostCenters", this.OnlyCostCenters);
			yield return new("onlyActive", this.OnlyActive);
		}
	}
}
