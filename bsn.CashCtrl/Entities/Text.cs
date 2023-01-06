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
			if (Id > 0) {
				yield return new KeyValuePair<string, object>("id", Id);
			}
			yield return new KeyValuePair<string, object>("type", Type);
			yield return new KeyValuePair<string, object>("name", Name);
			yield return new KeyValuePair<string, object>("isDefault", IsDefault);
			yield return new KeyValuePair<string, object>("value", Value);
		}
	}
}
