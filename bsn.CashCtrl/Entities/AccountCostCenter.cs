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
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)] set;
		}

		public double EndAmount {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)] set;
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
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)] set;
		}

		public bool IsInactive {
			get;
			set;
		}

		public bool? HasBalance {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)] set;
		}

		public LocalizedString FullName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)] set;
		}

		protected override IEnumerable<KeyValuePair<string, object>> ToParametersInternal() {
			yield return new KeyValuePair<string, object>("name", Name);
			yield return new KeyValuePair<string, object>("number", Number);
			yield return new KeyValuePair<string, object>("categoryId", CategoryId);
			yield return new KeyValuePair<string, object>("isInactive", IsInactive);
			yield return new KeyValuePair<string, object>("targetMin", TargetMin);
			yield return new KeyValuePair<string, object>("targetMax", TargetMax);
		}
	}
}
