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

		public OrderBookEntryType Type {
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
			get => amount.GetValueOrDefault();
			set => amount = double.IsNaN(value) ? default : value;
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
			if (Id > 0) {
				yield return new("id", Id);
				yield return new("orderId", OrderId);
			}
			yield return new("accountId", AccountId);
			yield return new("amount", amount);
			if (CurrencyId.HasValue) {
				yield return new("currencyId", CurrencyId);
				yield return new("currencyRate", CurrencyRate);
			}
			yield return new("date", Date);
			yield return new("description", Description);
			yield return new("reference", Reference);
			yield return new("taxId", TaxId);
			yield return new("templateId", TemplateId);
		}
	}
}