using System.Collections.Generic;
using System.ComponentModel;

namespace bsn.CashCtrl.Query {
	public class JournalImportEntryQuery: QueryBase {
		[Description("The ID of the fiscal period, from which we retrieve the imports. Leave empty to use the current fiscal period.")]
		public int? FiscalperiodId {
			get;
			set;
		}

		public override IEnumerable<KeyValuePair<string, object>> ToParameters() {
			foreach (var parameter in base.ToParameters()) {
				yield return parameter;
			}
			yield return new("fiscalPeriodId", this.FiscalperiodId);
		}
	}
}
