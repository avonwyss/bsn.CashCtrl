using System.Collections.Generic;
using System.Linq;

namespace bsn.CashCtrl.Query {
	public class FileQuery: QueryBase {
		public bool? Archived {
			get;
			set;
		}

		public string MimeType {
			get => MimeTypes.SingleOrDefault();
			set {
				MimeTypes.Clear();
				if (!string.IsNullOrEmpty(value)) {
					MimeTypes.Add(value);
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
			yield return new("archived", Archived);
			if (MimeTypes.Count > 0) {
				yield return new("mimeTypes", MimeTypes);
			}
			yield return new("onlyWithoutCategory", OnlyWithoutCategory);
			yield return new("withoutSub", WithoutSub);
		}
	}
}
