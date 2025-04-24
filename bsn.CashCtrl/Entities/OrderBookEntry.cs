using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class OrderBookEntry: EntityBase, IApiSerializable {
		private double? amount;

		public int? TemplateId {
			get;
			set;
		}

		public int OrderId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, false)]
			set;
		}

		public int AccountId {
			get;
			set;
		}

		public int? DebitId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? CreditId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? TaxId {
			get;
			set;
		}

		public int? CurrencyId {
			get;
			set;
		}

		public int? ImportEntryId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public BookEntryType Type {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public DateTime Date {
			get;
			set;
		}

		public string Description {
			get;
			set;
		}

		public double Amount {
			get => this.amount.GetValueOrDefault();
			set => this.amount = double.IsNaN(value) ? default : value;
		}

		public double? CurrencyRate {
			get;
			set;
		}

		public string Reference {
			get;
			set;
		}

		public AccountCostCenterAllocation[] Allocations {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Name {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string DebitName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string CreditName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double DefaultCurrencyAmount {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double NetAmount {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double TaxAmount {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsAllowTax {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new("id", this.Id);
				yield return new("orderId", this.OrderId);
			}
			yield return new("accountId", this.AccountId);
			yield return new("amount", this.amount);
			if (this.CurrencyId.HasValue) {
				yield return new("currencyId", this.CurrencyId);
				yield return new("currencyRate", this.CurrencyRate);
			}
			yield return new("date", this.Date);
			yield return new("description", this.Description);
			yield return new("reference", this.Reference);
			yield return new("taxId", this.TaxId);
			yield return new("templateId", this.TemplateId);
		}
	}
}
