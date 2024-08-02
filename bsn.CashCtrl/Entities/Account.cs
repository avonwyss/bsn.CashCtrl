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

		protected override IEnumerable<KeyValuePair<string, object>> ToParametersInternal() {
			yield return new KeyValuePair<string, object>("categoryId", this.CategoryId);
			yield return new KeyValuePair<string, object>("name", this.Name);
			yield return new KeyValuePair<string, object>("number", this.Number);
			yield return new KeyValuePair<string, object>("currencyId", this.CurrencyId);
			yield return new KeyValuePair<string, object>("isInactive", this.IsInactive);
			yield return new KeyValuePair<string, object>("targetMin", this.TargetMin);
			yield return new KeyValuePair<string, object>("targetMax", this.TargetMax);
			yield return new KeyValuePair<string, object>("taxId", this.TaxId);
		}
	}
}
