using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class PersonServicePeriod: EntityBase, IApiSerializable {
		public int PersonId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public DateTime DateEntry {
			get;
			set;
		}

		public DateTime? DateExit {
			get;
			set;
		}

		public string Notes {
			get;
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new("id", this.Id);
			}
			yield return new("dateEntry", this.DateEntry.ToCashCtrlString(true));
			yield return new("dateExit", this.DateExit.ToCashCtrlString(true));
			yield return new("notes", this.Notes);
		}
	}
}
