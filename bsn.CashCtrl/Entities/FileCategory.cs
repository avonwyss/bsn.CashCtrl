using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class FileCategory: EntityBase, IApiSerializable {
		public LocalizedString Name {
			get;
			set;
		}

		public int? ParentId {
			get;
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new("id", this.Id);
			}
			yield return new("name", this.Name);
			yield return new("parentId", this.ParentId);
		}
	}
}
