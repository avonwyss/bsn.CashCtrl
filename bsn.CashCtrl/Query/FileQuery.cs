using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using bsn.CashCtrl.Entities;

namespace bsn.CashCtrl.Query {
	public class FileQuery: PagedQuery {
		// ReSharper disable once FieldCanBeMadeReadOnly.Local - Must be read-write for cloning
		private readonly VirtualList<string> mimeTypes = new();

		[Description("The ID of the category to filter by.")]
		public int? CategoryId {
			get;
			set;
		}

		[Description("Get archived files (only active files otherwise). Defaults to false.")]
		public bool? Archived {
			get;
			set;
		}

		[Description("Filter the file list by a mime type. For example, use image/* to filter by images only.")]
		public string MimeType {
			get => this.MimeTypes.SingleOrDefault();
			set {
				this.MimeTypes.Clear();
				if (!string.IsNullOrEmpty(value)) {
					this.MimeTypes.Add(value);
				}
			}
		}

		[Description("Filter the file list by these mime types. For example, use image/* to filter by images only.")]
		public IList<string> MimeTypes {
			get => this.mimeTypes;
			set => this.mimeTypes.MakeSameAs(value);
		}

		[Description("Flag to include only files without a category. Defaults to false.")]
		private bool? OnlyWithoutCategory {
			get;
			set;
		}

		[Description("Flag to exclude files in sub-categories. Defaults to false.")]
		private bool? WithoutSub {
			get;
			set;
		}

		public override IEnumerable<KeyValuePair<string, object>> ToParameters() {
			foreach (var parameter in base.ToParameters()) {
				yield return parameter;
			}
			yield return new("categoryId", this.CategoryId);
			yield return new("archived", this.Archived);
			if (this.MimeTypes.Count > 0) {
				yield return new("mimeTypes", this.MimeTypes);
			}
			yield return new("onlyWithoutCategory", this.OnlyWithoutCategory);
			yield return new("withoutSub", this.WithoutSub);
		}
	}
}
