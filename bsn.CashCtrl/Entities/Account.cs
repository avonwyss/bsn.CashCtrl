using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace bsn.CashCtrl.Entities {
	public class Account: AllocationsEntityBase, IApiSerializable {
		public int? CategoryId {
			get;
			set;
		}

		public LocalizedString CategoryDisplay {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public AccountClass AccountClass {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? TaxId {
			get;
			set;
		}

		public LocalizedString TaxName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? CurrencyId {
			get;
			set;
		}

		public string CurrencyCode {
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

		public string CostCenterNumbers {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
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

		public double DefaultCurrencyOpeningAmount {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double DefaultCurrencyEndAmount {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsInactive {
			get;
			set;
		}

		public AccountDefaults Defaults {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
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

		public LocalizedString DisplayValue {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool? DefaultCurrency {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool? ForeignCurrency {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public override IEnumerable<KeyValuePair<string, object>> ToParameters() {
			foreach (var pair in base.ToParameters()) {
				yield return pair;
			}
			yield return new("categoryId", this.CategoryId);
			yield return new("name", this.Name);
			yield return new("number", this.Number);
			yield return new("currencyId", this.CurrencyId);
			yield return new("isInactive", this.IsInactive);
			yield return new("targetMin", this.TargetMin);
			yield return new("targetMax", this.TargetMax);
			yield return new("taxId", this.TaxId);
		}
	}
}
