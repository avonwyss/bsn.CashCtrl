using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class AccountCostCenter: ExtensibleEntityBase, IApiSerializable {
		public int? CategoryId {
			get;
			set;
		}

		public LocalizedString CategoryName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
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

		public double OpeningAmount {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double EndAmount {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double TargetMin {
			get;
			set;
		}

		public double TargetMax {
			get;
			set;
		}

		public string TargetDisplay {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsInactive {
			get;
			set;
		}

		public bool? HasBalance {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public LocalizedString FullName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public override IEnumerable<KeyValuePair<string, object>> ToParameters() {
			foreach (var pair in base.ToParameters()) {
				yield return pair;
			}
			yield return new("name", this.Name);
			yield return new("number", this.Number);
			yield return new("categoryId", this.CategoryId);
			yield return new("isInactive", this.IsInactive);
			yield return new("targetMin", this.TargetMin);
			yield return new("targetMax", this.TargetMax);
		}
	}
}
