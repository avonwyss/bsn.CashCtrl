using System.Collections.Generic;

namespace bsn.CashCtrl.Query {
	public class InventoryAssetQuery: QueryBase {
		public int? FiscalPeriodId {
			get;
			set;
		}

		public bool? OnlyActive {
			get;
			set;
		}

		public bool? OnlyWithImages {
			get;
			set;
		}

		public bool? OnlyWithoutCategory {
			get;
			set;
		}

		public bool? OnlyWithoutDeprType {
			get;
			set;
		}

		protected override IEnumerable<KeyValuePair<string, object>> ToParametersInternal() {
			yield return new("fiscalPeriodId", this.FiscalPeriodId);
			yield return new("onlyActive", this.OnlyActive);
			yield return new("onlyWithImages", this.OnlyWithImages);
			yield return new("onlyWithoutCategory", this.OnlyWithoutCategory);
			yield return new("onlyWithoutDeprType", this.OnlyWithoutDeprType);
		}
	}
}
