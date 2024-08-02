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
			yield return new("mimeType", this.MimeType);
			yield return new("name", this.Name);
			if (this.CategoryId.HasValue) {
				yield return new("categoryId", this.CategoryId);
			}
			if (this.Size.HasValue) {
				yield return new("size", this.Size);
			}
		}
	}
}
