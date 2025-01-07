using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace bsn.CashCtrl.Entities {
	public class JournalImportEntry: AllocationsEntityBase {
		private int accountId;
		private AccountClass accountClass;
		private int? contraAccountId;
		private Account contraAccount;

		public int ImportId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? JournalId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int AccountId {
			get => this.Account?.Id ?? this.accountId;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => this.accountId = value;
		}

		public AccountClass AccountClass {
			get => this.Account?.AccountClass ?? this.accountClass;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => this.accountClass = value;
		}

		public int? DebitId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? GuessedDebitId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string DebitName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? CreditId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? GuessedCreditId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string CreditName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? AssociateId {
			get;
			set;
		}

		public int? GuessedAssociateId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string AssociateName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? TaxId {
			get;
			set;
		}

		public int? GuessedTaxId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string TaxName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? OrderId {
			get;
			set;
		}

		public int? GuessedOrderId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? OrderStatusId {
			get;
			set;
		}

		public string StatusName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public OrderStatusIcon Icon {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public JournalType Type {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public BookType DebitOrCredit {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public DateTime DateAdded {
			get;
			set;
		}

		public string Title {
			get;
			set;
		}

		public string GuessedTitle {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Reference {
			get;
			set;
		}

		public string GuessedReference {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double Amount {
			get;
			set;
		}

		public double OriginalAmount {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? CurrencyId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double CurrencyRate {
			get;
			set;
		} = 1.0;

		public string CurrencyCode {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double Balance {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string NameSingular {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public OrderType OrderType {
			get;
			set;
		}

		public string CostCenterNumbers {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool Confirmed {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool Imported {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool Split {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool Deleted {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool Duplicate {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string RawText {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double? JournalBalanceBefore {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double? JournalBalanceAfter {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double? RemainderAmount {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Cls {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string SourceIdHash {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		[JsonConverter(typeof(JsonStringConverter))]
		public Dictionary<string, string[]> SourceMappingHashes {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		// ReSharper disable once ConvertToAutoPropertyWhenPossible
		public Account ContraAccount {
			get => this.contraAccount;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => this.contraAccount = value;
		}

		public int? ContraAccountId {
			get => this.ContraAccount?.Id ?? this.contraAccountId;
			set {
				this.contraAccountId = value;
				this.contraAccount = null;
			}
		}

		public Account Account {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public override IEnumerable<KeyValuePair<string, object>> ToParameters() {
			foreach (var pair in base.ToParameters()) {
				yield return pair;
			}
			yield return new("id", this.Id);
			yield return new("amount", this.Amount);
			yield return new("contraAccountId", this.ContraAccountId);
			yield return new("dateAdded", this.DateAdded);
			yield return new("associateId", this.AssociateId);
			yield return new("currencyId", this.CurrencyId);
			yield return new("currencyRate", this.CurrencyRate);
			yield return new("orderId", this.OrderId);
			yield return new("orderStatusId", this.OrderStatusId);
			yield return new("reference", this.Reference);
			yield return new("taxId", this.TaxId);
			yield return new("title", this.Title);
		}
	}
}
