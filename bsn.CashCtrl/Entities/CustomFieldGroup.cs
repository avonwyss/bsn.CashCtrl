using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class CustomFieldGroup: EntityBase, IApiSerializable {
		public List<CustomField> CustomFields {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public LocalizedString Name {
			get;
			set;
		}

		public int Pos {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public CustomFieldType Type {
			get;
			set;
		}

		public string Value {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Text {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (Id > 0) {
				yield return new KeyValuePair<string, object>("id", Id);
			}
			yield return new KeyValuePair<string, object>("name", Name);
			yield return new KeyValuePair<string, object>("type", Type);
		}
	}
}
