using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace bsn.CashCtrl.Query {
	public class InventoryArticleQuery: PagedQuery {
		[Description("The ID of the category to filter by.")]
		public int? CategoryId {
			get;
			set;
		}

		[Description("Flag to include only active articles. Defaults to false.")]
		public bool? OnlyActive {
			get;
			set;
		}

		[Description("Flag to only include entries with cost centers. Defaults to false.")]
		public bool? OnlyCostCenters {
			get;
			set;
		}

		[Description("Flag to include only articles that need to be restocked. Defaults to false.")]
		public bool? OnlyRestock {
			get;
			set;
		}

		[Description("Flag to include only articles with images. Defaults to false.")]
		public bool? OnlyWithImages {
			get;
			set;
		}

		[Description("Flag to include only articles without a category. Defaults to false.")]
		public bool? OnlyWithoutCategory {
			get;
			set;
		}

		public override IEnumerable<KeyValuePair<string, object>> ToParameters() {
			foreach (var parameter in base.ToParameters()) {
				yield return parameter;
			}
			yield return new("categoryId", this.CategoryId);
			yield return new("onlyActive", this.OnlyActive);
			yield return new("onlyCostCenters", this.OnlyCostCenters);
			yield return new("onlyRestock", this.OnlyRestock);
			yield return new("onlyWithImages", this.OnlyWithImages);
			yield return new("onlyWithoutCategory", this.OnlyWithoutCategory);
		}
	}
}
