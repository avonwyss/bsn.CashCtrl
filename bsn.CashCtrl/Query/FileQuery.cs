using System.Collections.Generic;
using System.Linq;

namespace bsn.CashCtrl.Query {
	public class FileQuery: QueryBase {
		public bool? Archived {
			get;
			set;
		}

		public string MimeType {
			get => this.MimeTypes.SingleOrDefault();
			set {
				this.MimeTypes.Clear();
				if (!string.IsNullOrEmpty(value)) {
					this.MimeTypes.Add(value);
				}
			}
		}

		public List<string> MimeTypes {
			get;
		} = new List<string>(0);

		private bool? OnlyWithoutCategory {
			get;
			set;
		}

		private bool? WithoutSub {
			get;
			set;
		}

		protected override IEnumerable<KeyValuePair<string, object>> ToParametersInternal() {
			yield return new("archived", this.Archived);
			if (this.MimeTypes.Count > 0) {
				yield return new("mimeTypes", this.MimeTypes);
			}
			yield return new("onlyWithoutCategory", this.OnlyWithoutCategory);
			yield return new("withoutSub", this.WithoutSub);
		}
	}
}
