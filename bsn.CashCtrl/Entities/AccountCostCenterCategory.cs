using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace bsn.CashCtrl.Entities {
	public class AccountCostCenterCategory: EntityBase, IApiSerializable {
		public int? ParentId {
			get;
			set;
		}

		public string Number {
			get;
			set;
		}

		public LocalizedString Name {
			get;
			set;
		}

		public LocalizedString FullName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)] set;
		}

		public int? SequenceNrIdInherited {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)] set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new KeyValuePair<string, object>("id", this.Id);
			}
			yield return new KeyValuePair<string, object>("name", this.Name);
			yield return new KeyValuePair<string, object>("number", this.Number);
			yield return new KeyValuePair<string, object>("parentId", this.ParentId);
		}
	}
}
