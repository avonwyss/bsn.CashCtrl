using System;

namespace bsn.CashCtrl.Entities {
	public class PreparedFile {
		public int FileId {
			get;
			set;
		}

		public Uri WriteUrl {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public string MimeType {
			get;
			set;
		}
	}
}