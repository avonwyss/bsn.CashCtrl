using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class Text: EntityBase, IApiSerializable {
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
				yield return new KeyValuePair<string, object>("id", this.Id);
			}
			yield return new KeyValuePair<string, object>("type", this.Type);
			yield return new KeyValuePair<string, object>("name", this.Name);
			yield return new KeyValuePair<string, object>("isDefault", this.IsDefault);
			yield return new KeyValuePair<string, object>("value", this.Value);
		}
	}
}
