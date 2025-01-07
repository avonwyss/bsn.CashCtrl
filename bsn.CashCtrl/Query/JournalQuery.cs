using System.Collections.Generic;
using System.ComponentModel;

namespace bsn.CashCtrl.Query {
	public class JournalQuery: PagedQuery {
		[Description("Optional ID of account to retrieve the journal for that specific account.")]
		public int? AccountId {
			get;
			set;
		}

		[Description("The ID of the fiscal period, from which we retrieve the entries. Leave empty to use the current fiscal period.")]
		public int? FiscalperiodId {
			get;
			set;
		}

		[Description("Flag to only include collective book entries. Defaults to false.")]
		public bool? OnlyCollective {
			get;
			set;
		}

		[Description("Flag to only include entries with cost centers. Defaults to false.")]
		public bool? OnlyCostCenters {
			get;
			set;
		}

		[Description("Flag to only include imported book entries. Defaults to false.")]
		public bool? OnlyImported {
			get;
			set;
		}

		[Description("Flag to only include manual book entries. Defaults to false.")]
		public bool? OnlyManual {
			get;
			set;
		}

		[Description("Flag to only include untaxed book entries. Defaults to false.")]
		public bool? OnlyUntaxed {
			get;
			set;
		}

		public override IEnumerable<KeyValuePair<string, object>> ToParameters() {
			foreach (var parameter in base.ToParameters()) {
				yield return parameter;
			}
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
