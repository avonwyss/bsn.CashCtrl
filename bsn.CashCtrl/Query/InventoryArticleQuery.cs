using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Query {
	public class InventoryArticleQuery: QueryBase {
		public bool? OnlyActive {
			get;
			set;
		}

		public bool? OnlyCostCenters {
			get;
			set;
		}

		public bool? OnlyRestock {
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

		protected override IEnumerable<KeyValuePair<string, object>> ToParametersInternal() {
			yield return new("onlyActive", this.OnlyActive);
			yield return new("onlyCostCenters", this.OnlyCostCenters);
			yield return new("onlyRestock", this.OnlyRestock);
			yield return new("onlyWithImages", this.OnlyWithImages);
			yield return new("onlyWithoutCategory", this.OnlyWithoutCategory);
		}
	}
}
