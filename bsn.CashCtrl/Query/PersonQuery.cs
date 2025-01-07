using System.Collections.Generic;
using System.ComponentModel;

namespace bsn.CashCtrl.Query {
	public class PersonQuery: PagedQuery {
		[Description("The ID of the category to filter by.")]
		public int? CategoryId {
			get;
			set;
		}

		[Description("Flag to include only active people. Defaults to false.")]
		public bool? OnlyActive {
			get;
			set;
		}

		[Description("Flag to include only people with images. Defaults to false.")]
		public bool? OnlyWithImages {
			get;
			set;
		}

		[Description("Flag to include only people without a category. Defaults to false.")]
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
			yield return new("onlyWithImages", this.OnlyWithImages);
			yield return new("onlyWithoutCategory", this.OnlyWithoutCategory);
		}
	}
}
