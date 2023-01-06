using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class PersonTitle: EntityBase, IApiSerializable {
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
			if (Id > 0) {
				yield return new("id", Id);
			}
			yield return new("name", Name);
			yield return new("gender", Gender);
			yield return new("sentence", Sentence);
		}
	}
}