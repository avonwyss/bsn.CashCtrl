using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace bsn.CashCtrl.Entities {
	public class Journal: AllocationsEntityBase {
		private int itemsCount;
		private JournalType type;
		private int? sequenceNumberId;

		public int DebitId {
			get;
			set;
		}

		public string DebitName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int CreditId {
			get;
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

		public string AssociateName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? TaxId {
			get;
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

		public string OrderBookEntryId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? InventoryId {
			get;
			set;
		}

		public string ImportEntryId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public JournalType Type {
			get => this.Items != null ? JournalType.Collective : this.type;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => this.type = value;
		}

		public DateTime DateAdded {
			get;
			set;
		}

		public string Title {
			get;
			set;
		}

		public string Reference {
			get;
			set;
		}

		public double Amount {
			get;
			set;
		}

		public int? CurrencyId {
			get;
			set;
		}

		public double CurrencyRate {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string CurrencyCode {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? AccountId {
			get;
			set;
		}

		public int? AccountCurrencyId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string AccountClass {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double Balance {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public LocalizedString NameSingular {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public OrderType OrderType {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int ItemsCount {
			get => this.Items?.Count ?? this.itemsCount;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => this.itemsCount = value;
		}

		public JournalRecurrence? Recurrence {
			get;
			set;
		}

		public DateTime StartDate {
			get;
			set;
		}

		public DateTime EndDate {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? DaysBefore {
			get;
			set;
		}

		public NotifyType? NotifyType {
			get;
			set;
		}

		public int? NotifyPersonId {
			get;
			set;
		}

		public int? NotifyUserId {
			get;
			set;
		}

		public string NotifyEmail {
			get;
			set;
		}

		public string CostCenterNumbers {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool Imported {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string ImportedBy {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsRecurring {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? RecurrenceId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public CloneableList<JournalItem> Items {
			get;
			set;
		}

		[JsonConverter(typeof(JsonStringConverter))]
		public int[] AccountIds {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string ItemsIndex {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool? Taxed {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double? DefaultCurrencyTaxAmount {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public JToken TaxWhich {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public Account[] AffectedAccounts {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public JObject[] TaxedItems {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public Person[] Associates {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double? DefaultCurrencyNetAmount {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public Account[] MainAccounts {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double? DefaultCurrencyAmount {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double? NetAmount {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double? TaxAmount {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? SequenceNumberId {
			[Obsolete(CashCtrlClient.EntityFieldMissing, false)]
			get => this.sequenceNumberId;
			set => this.sequenceNumberId = value;
		}

		protected override IEnumerable<KeyValuePair<string, object>> ToParametersInternal() {
			if (this.Items?.Count > 0) {
				yield return new("items", this.Items);
			} else {
				yield return new("amount", this.Amount);
				yield return new("creditId", this.CreditId);
				yield return new("debitId", this.DebitId);
			}
			yield return new("associateId", this.AssociateId);
			yield return new("currencyId", this.CurrencyId);
			yield return new("currencyRate", this.CurrencyRate);
			yield return new("dateAdded", this.DateAdded);
			yield return new("accountId", this.AccountId);
			yield return new("reference", this.Reference);
			yield return new("sequenceNumberId", this.sequenceNumberId);
			yield return new("taxId", this.TaxId);
			yield return new("title", this.Title);
			yield return new("daysBefore", this.DaysBefore);
			yield return new("endDate", this.EndDate.ToCashCtrlString(true));
			yield return new("notifyEmail", this.NotifyEmail);
			yield return new("notifyPersonId", this.NotifyPersonId);
			yield return new("notifyType", this.NotifyType);
			yield return new("notifyUserId", this.NotifyUserId);
			yield return new("recurrence", this.Recurrence);
			yield return new("startDate", this.StartDate.ToCashCtrlString(true));
		}
	}
}
