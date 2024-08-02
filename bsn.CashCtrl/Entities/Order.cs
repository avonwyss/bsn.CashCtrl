using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class Order: AllocationsEntityBase {
		private int? sequenceNumberId;

		public int AssociateId {
			get;
			set;
		}

		public string AssociateName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? ResponsiblePersonId {
			get;
			set;
		}

		public string ResponsiblePersonName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? AccountId {
			get;
			set;
		}

		public string Account {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int CategoryId {
			get;
			set;
		}

		public string ActionId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? GroupId {
			get;
			set;
		}

		public int? PreviousId {
			get;
			set;
		}

		public int? StatusId {
			get;
			set;
		}

		public OrderType Type {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public BookType BookType {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public LocalizedString StatusName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? SentStatusId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? RoundingId {
			get;
			set;
		}

		public OrderStatusIcon Icon {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public LocalizedString NameSingular {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public LocalizedString NamePlural {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public DateTime Date {
			get;
			set;
		}

		public DateTime? DateDue {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Nr {
			get;
			set;
		}

		public string Description {
			get;
			set;
		}

		public int? DueDays {
			get;
			set;
		}

		public int? CurrencyId {
			get;
			set;
		}

		public double? CurrencyRate {
			get;
			set;
		}

		public double DiscountPercentage {
			get;
			set;
		}

		public string CurrencyCode {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double SubTotal {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double Tax {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double Total {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double Open {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double GroupOpen {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public DateTime? DateDeliveryStart {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public DateTime? DateDeliveryEnd {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public DateTime? DateLastBooked {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Language {
			get;
			set;
		}

		public JournalRecurrence Recurrence {
			get;
			set;
		}

		public DateTime? StartDate {
			get;
			set;
		}

		public DateTime? EndDate {
			get;
			set;
		}

		public int? DaysBefore {
			get;
			set;
		}

		public NotifyType NotifyType {
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

		public bool? Sent {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string SentBy {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public DateTime? Downloaded {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string DownloadedBy {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsBook {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsRemoveStock {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsAddStock {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsClosed {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool HasDueDays {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsDisplayItemGross {
			get;
			set;
		}

		public bool IsRecurring {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsCreditNote {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool? RecurrenceId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public List<OrderItem> Items {
			get;
			set;
		} = new(0);

		public int? FileId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public TaxType TaxType {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string QrReference {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double? Paid {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double? RoundingDifference {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string ForeignCurrency {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Iso11649Reference {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double DefaultCurrencyTotal {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool Due {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsFileReplacement {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool HasRecurrence {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		// ReSharper disable once ConvertToAutoPropertyWhenPossible
		public int? SequenceNumberId {
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			get => this.sequenceNumberId;
			set => this.sequenceNumberId = value;
		}

		protected override IEnumerable<KeyValuePair<string, object>> ToParametersInternal() {
			yield return new KeyValuePair<string, object>("associateId", this.AssociateId);
			yield return new KeyValuePair<string, object>("categoryId", this.CategoryId);
			yield return new KeyValuePair<string, object>("date", this.Date);
			yield return new KeyValuePair<string, object>("accountId", this.AccountId);
			yield return new KeyValuePair<string, object>("currencyId", this.CurrencyId);
			yield return new KeyValuePair<string, object>("currencyRate", this.CurrencyRate);
			yield return new KeyValuePair<string, object>("daysBefore", this.DaysBefore);
			yield return new KeyValuePair<string, object>("description", this.Description);
			yield return new KeyValuePair<string, object>("discountPercentage", this.DiscountPercentage);
			yield return new KeyValuePair<string, object>("dueDays", this.DueDays);
			yield return new KeyValuePair<string, object>("endDate", this.EndDate);
			yield return new KeyValuePair<string, object>("groupId", this.GroupId);
			yield return new KeyValuePair<string, object>("isDisplayItemGross", this.IsDisplayItemGross);
			yield return new KeyValuePair<string, object>("items", this.Items);
			yield return new KeyValuePair<string, object>("language", this.Language);
			yield return new KeyValuePair<string, object>("notifyEmail", this.NotifyEmail);
			yield return new KeyValuePair<string, object>("notifyPersonId", this.NotifyPersonId);
			yield return new KeyValuePair<string, object>("notifyType", this.NotifyType);
			yield return new KeyValuePair<string, object>("notifyUserId", this.NotifyUserId);
			if (!string.IsNullOrEmpty(this.Nr)) {
				yield return new KeyValuePair<string, object>("nr", this.Nr);
			}
			yield return new KeyValuePair<string, object>("previousId", this.PreviousId);
			yield return new KeyValuePair<string, object>("recurrence", this.Recurrence);
			yield return new KeyValuePair<string, object>("responsiblePersonId", this.ResponsiblePersonId);
			yield return new KeyValuePair<string, object>("roundingId", this.RoundingId);
			yield return new KeyValuePair<string, object>("sequenceNumberId", this.sequenceNumberId);
			yield return new KeyValuePair<string, object>("startDate", this.StartDate);
			yield return new KeyValuePair<string, object>("statusId", this.StatusId);
		}
	}
}
