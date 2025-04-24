using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class PersonTitle: FullEntityBase, IApiSerializable {
		public LocalizedString Name {
			get;
			set;
		}

		public string Sentence {
			get;
			set;
		}

		public PersonGender? Gender {
			get;
			set;
		}

		public string Text {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Value {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new("id", this.Id);
			}
			yield return new("name", this.Name);
			yield return new("gender", this.Gender);
			yield return new("sentence", this.Sentence);
		}
	}
}
