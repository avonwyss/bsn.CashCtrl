using System.Collections.Generic;
using System.ComponentModel;

namespace bsn.CashCtrl.Query {
	public class InventoryAssetQuery: PagedQuery {
		[Description("The ID of the category to filter by.")]
		public int? CategoryId {
			get;
			set;
		}

		[Description("The ID of the fiscal period, from which we retrieve the current values. Leave empty to use the current fiscal period.")]
		public int? FiscalperiodId {
			get;
			set;
		}

		[Description("Flag to include only active fixed assets. Defaults to false.")]
		public bool? OnlyActive {
			get;
			set;
		}

		[Description("Flag to include only fixed assets with images. Defaults to false.")]
		public bool? OnlyWithImages {
			get;
			set;
		}

		[Description("Flag to include only fixed assets without a category. Defaults to false.")]
		public bool? OnlyWithoutCategory {
			get;
			set;
		}

		[Description("Flag to include only fixed assets without depreciation configured. Defaults to false.")]
		public bool? OnlyWithoutDeprType {
			get;
			set;
		}

		public override IEnumerable<KeyValuePair<string, object>> ToParameters() {
			foreach (var parameter in base.ToParameters()) {
				yield return parameter;
			}
			yield return new("categoryId", this.CategoryId);
			yield return new("fiscalPeriodId", this.FiscalperiodId);
			yield return new("onlyActive", this.OnlyActive);
			yield return new("onlyWithImages", this.OnlyWithImages);
			yield return new("onlyWithoutCategory", this.OnlyWithoutCategory);
			yield return new("onlyWithoutDeprType", this.OnlyWithoutDeprType);
		}
	}
}
