using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class PersonContact: EntityBase, IApiSerializable {
		internal static bool IsNotEmpty(PersonContact contact) {
			return !string.IsNullOrEmpty(contact.Address);
		}

		public int PersonId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public PersonContactType Type {
			get;
			set;
		}

		public string Purpose {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Address {
			get;
			set;
		}

		public int Pos {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			yield return new("address", this.Address);
			yield return new("type", this.Type);
		}
	}
}
