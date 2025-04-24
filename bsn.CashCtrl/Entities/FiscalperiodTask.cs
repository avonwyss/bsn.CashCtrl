using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class FiscalperiodTask: FullEntityBase, IApiSerializable {
		public string Name {
			get;
			set;
		}

		public int UserId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			yield return new("name", this.Name);
		}
	}
}
