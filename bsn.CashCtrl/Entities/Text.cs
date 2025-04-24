using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class Text: FullEntityBase, IApiSerializable {
		public string Name {
			get;
			set;
		}

		public TextType Type {
			get;
			set;
		}

		public bool IsDefault {
			get;
			set;
		}

		public string Value {
			get;
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new("id", this.Id);
			}
			yield return new("type", this.Type);
			yield return new("name", this.Name);
			yield return new("isDefault", this.IsDefault);
			yield return new("value", this.Value);
		}
	}
}
