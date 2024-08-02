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
			if (this.Id > 0) {
				yield return new KeyValuePair<string, object>("id", this.Id);
			}
			yield return new KeyValuePair<string, object>("accountId", this.AccountId);
			yield return new KeyValuePair<string, object>("name", this.Name);
			yield return new KeyValuePair<string, object>("percentage", this.Percentage);
			yield return new KeyValuePair<string, object>("calcType", this.CalcType);
			yield return new KeyValuePair<string, object>("documentName", this.DocumentName);
			yield return new KeyValuePair<string, object>("isInactive", this.IsInactive);
			yield return new KeyValuePair<string, object>("percentageFlat", this.PercentageFlat);
		}
	}
}
