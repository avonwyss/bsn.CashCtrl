using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class FilePreparation: IApiSerializable {
		public string MimeType {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public int? CategoryId {
			get;
			set;
		}

		public int? Size {
			get;
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			yield return new("mimeType", MimeType);
			yield return new("name", Name);
			if (CategoryId.HasValue) {
				yield return new("categoryId", CategoryId);
			}
			if (Size.HasValue) {
				yield return new("size", Size);
			}
		}
	}
}
