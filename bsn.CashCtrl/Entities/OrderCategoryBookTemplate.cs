using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class OrderCategoryBookTemplate: FullEntityBase, IApiSerializable {
		public int CategoryId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? AccountId {
			get;
			set;
		}

		public int? TaxId {
			get;
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

		public bool IsAllowTax {
			get;
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			yield return new("accountId", this.AccountId);
			yield return new("name", this.Name);
			yield return new("isAllowTax", this.IsAllowTax);
			yield return new("taxId", this.TaxId);
		}
	}
}
