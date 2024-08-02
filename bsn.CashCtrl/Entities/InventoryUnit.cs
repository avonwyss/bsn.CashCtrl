using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class InventoryUnit: EntityBase, IApiSerializable {
		public LocalizedString Name {
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
				yield return new KeyValuePair<string, object>("id", this.Id);
			}
			yield return new KeyValuePair<string, object>("name", this.Name);
		}
	}
}
