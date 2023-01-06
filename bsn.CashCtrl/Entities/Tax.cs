using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class Tax: EntityBase, IApiSerializable {
		public int AccountId {
			get;
			set;
		}

		public LocalizedString Name {
			get;
			set;
		}

		public double Percentage {
			get;
			set;
		}

		public TaxCalcType CalcType {
			get;
			set;
		} = TaxCalcType.Net;

		public LocalizedString DocumentName {
			get;
			set;
		}

		public bool IsInactive {
			get;
			set;
		}

		public double? PercentageFlat {
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

		public string AccountDisplay {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string ListCls {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsPretax {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsFlat {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsGrossCalcType {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (Id > 0) {
				yield return new KeyValuePair<string, object>("id", Id);
			}
			yield return new KeyValuePair<string, object>("accountId", AccountId);
			yield return new KeyValuePair<string, object>("name", Name);
			yield return new KeyValuePair<string, object>("percentage", Percentage);
			yield return new KeyValuePair<string, object>("calcType", CalcType);
			yield return new KeyValuePair<string, object>("documentName", DocumentName);
			yield return new KeyValuePair<string, object>("isInactive", IsInactive);
			yield return new KeyValuePair<string, object>("percentageFlat", PercentageFlat);
		}
	}
}
