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
			get => Items != null ? JournalType.Collective : type;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => type = value;
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
			get => Items?.Count ?? itemsCount;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => itemsCount = value;
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

		public List<JournalItem> Items {
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
			get => sequenceNumberId;
			set => sequenceNumberId = value;
		}

		protected override IEnumerable<KeyValuePair<string, object>> ToParametersInternal() {
			if (Items?.Count > 0) {
				yield return new KeyValuePair<string, object>("items", Items);
			} else {
				yield return new KeyValuePair<string, object>("amount", Amount);
				yield return new KeyValuePair<string, object>("creditId", CreditId);
				yield return new KeyValuePair<string, object>("debitId", DebitId);
			}
			yield return new KeyValuePair<string, object>("associateId", AssociateId);
			yield return new KeyValuePair<string, object>("currencyId", CurrencyId);
			yield return new KeyValuePair<string, object>("currencyRate", CurrencyRate);
			yield return new KeyValuePair<string, object>("dateAdded", DateAdded.ToCashCtrlString(true));
			yield return new KeyValuePair<string, object>("accountId", AccountId);
			yield return new KeyValuePair<string, object>("reference", Reference);
			yield return new KeyValuePair<string, object>("sequenceNumberId", sequenceNumberId);
			yield return new KeyValuePair<string, object>("taxId", TaxId);
			yield return new KeyValuePair<string, object>("title", Title);
			foreach (var recurrenceParameter in ToRecurrenceParameters()) {
				yield return recurrenceParameter;
			}
		}

		public IEnumerable<KeyValuePair<string, object>> ToRecurrenceParameters() {
			yield return new KeyValuePair<string, object>("id", Id);
			yield return new KeyValuePair<string, object>("daysBefore", DaysBefore);
			yield return new KeyValuePair<string, object>("endDate", EndDate);
			yield return new KeyValuePair<string, object>("notifyEmail", NotifyEmail);
			yield return new KeyValuePair<string, object>("notifyPersonId", NotifyPersonId);
			yield return new KeyValuePair<string, object>("notifyType", NotifyType);
			yield return new KeyValuePair<string, object>("notifyUserId", NotifyUserId);
			yield return new KeyValuePair<string, object>("recurrence", Recurrence);
			yield return new KeyValuePair<string, object>("startDate", StartDate.ToCashCtrlString(true));
		}
	}
}
