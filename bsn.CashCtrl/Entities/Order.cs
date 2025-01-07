using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class Order: ExtensibleEntityBase {
		private int? sequenceNumberId;
		// ReSharper disable once FieldCanBeMadeReadOnly.Local - Must be read-write for cloning
		private VirtualList<OrderItem> items = new();

		public override bool Partial => base.Partial || this.items.HasVirtualValues;

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

		public IList<OrderItem> Items {
			get => this.items;
			set => this.items.MakeSameAs(value);
		}

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

		public override IEnumerable<KeyValuePair<string, object>> ToParameters() {
			foreach (var pair in base.ToParameters()) {
				yield return pair;
			}
			yield return new("associateId", this.AssociateId);
			yield return new("categoryId", this.CategoryId);
			yield return new("date", this.Date);
			yield return new("accountId", this.AccountId);
			yield return new("currencyId", this.CurrencyId);
			yield return new("currencyRate", this.CurrencyRate);
			yield return new("daysBefore", this.DaysBefore);
			yield return new("description", this.Description);
			yield return new("discountPercentage", this.DiscountPercentage);
			yield return new("dueDays", this.DueDays);
			yield return new("endDate", this.EndDate.ToCashCtrlString(true));
			yield return new("groupId", this.GroupId);
			yield return new("isDisplayItemGross", this.IsDisplayItemGross);
			yield return new("items", this.Items);
			yield return new("language", this.Language);
			yield return new("notifyEmail", this.NotifyEmail);
			yield return new("notifyPersonId", this.NotifyPersonId);
			yield return new("notifyType", this.NotifyType);
			yield return new("notifyUserId", this.NotifyUserId);
			if (!string.IsNullOrEmpty(this.Nr)) {
				yield return new("nr", this.Nr);
			}
			yield return new("previousId", this.PreviousId);
			yield return new("recurrence", this.Recurrence);
			yield return new("responsiblePersonId", this.ResponsiblePersonId);
			yield return new("roundingId", this.RoundingId);
			yield return new("sequenceNumberId", this.sequenceNumberId);
			yield return new("startDate", this.StartDate.ToCashCtrlString(true));
			yield return new("statusId", this.StatusId);
		}
	}
}
