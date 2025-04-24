using System;
using System.Collections.Generic;
using System.Linq;

namespace bsn.CashCtrl.Entities {
	public class OrderCategory: FullEntityBase, IApiSerializable {
		// ReSharper disable once FieldCanBeMadeReadOnly.Local - Must be read-write for cloning
		private VirtualList<OrderCategoryStatus> status = new();
		// ReSharper disable once FieldCanBeMadeReadOnly.Local - Must be read-write for cloning
		private VirtualList<OrderCategoryBookTemplate> bookTemplates = new();

		public int AccountId {
			get;
			set;
		}

		public int? CurrencyId {
			get;
			set;
		}

		public IList<OrderCategoryStatus> Status {
			get => this.status;
			set => this.status.MakeSameAs(value);
		}

		public IList<OrderCategoryBookTemplate> BookTemplates {
			get => this.bookTemplates;
			set => this.bookTemplates.MakeSameAs(value);
		}

		public int? SequenceNrId {
			get;
			set;
		}

		public int? TemplateId {
			get;
			set;
		}

		public int? SentStatusId {
			get;
			set;
		}

		public int? ResponsiblePersonId {
			get;
			set;
		}

		public int? RoundingId {
			get;
			set;
		}

		public int? FileId {
			get;
			set;
		}

		public Attachment[] Attachments {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public LocalizedString NameSingular {
			get;
			set;
		}

		public LocalizedString NamePlural {
			get;
			set;
		}

		public OrderType Type {
			get;
			set;
		}

		public BookType BookType {
			get;
			set;
		}

		public PersonAddressType AddressType {
			get;
			set;
		}

		public int? DueDays {
			get;
			set;
		}

		public string Header {
			get;
			set;
		}

		public string Footer {
			get;
			set;
		}

		public string Mail {
			get;
			set;
		}

		public int Pos {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Text {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string TypeName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public LocalizedString Name {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Value {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? DefaultStatusId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? SequenceNrIdInherited {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string ResponsiblePersonName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsFree {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsInactive {
			get;
			set;
		}

		public bool HasDueDays {
			get;
			set;
		}

		public bool IsDisplayPrices {
			get;
			set;
		}

		public bool IsDisplayItemGross {
			get;
			set;
		}

		public bool IsSwitchRecipient {
			get;
			set;
		}

		public void ApplyBookTemplate(OrderBookEntry bookEntry, int templateId, string language = default) {
			var template = this.BookTemplates.Single(bt => bt.Id == templateId);
			bookEntry.TemplateId = template.Id;
			if (template.AccountId.HasValue) {
				bookEntry.AccountId = template.AccountId.Value;
			}
			bookEntry.Description = template.Name.ToString(language);
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new("id", this.Id);
			}
			yield return new("accountId", this.AccountId);
			yield return new("namePlural", this.NamePlural);
			yield return new("nameSingular", this.NameSingular);
			yield return new("status", this.Status);
			yield return new("addressType", this.AddressType);
			yield return new("bookTemplates", this.BookTemplates);
			yield return new("bookType", this.BookType);
			yield return new("currencyId", this.CurrencyId);
			yield return new("dueDays", this.DueDays);
			yield return new("fileId", this.FileId);
			yield return new("footer", this.Footer);
			yield return new("hasDueDays", this.HasDueDays);
			yield return new("header", this.Header);
			yield return new("isDisplayItemGross", this.IsDisplayItemGross);
			yield return new("isDisplayPrices", this.IsDisplayPrices);
			yield return new("isInactive", this.IsInactive);
			yield return new("isSwitchRecipient", this.IsSwitchRecipient);
			yield return new("mail", this.Mail);
			yield return new("responsiblePersonId", this.ResponsiblePersonId);
			yield return new("roundingId", this.RoundingId);
			yield return new("sentStatusId", this.SentStatusId);
			yield return new("sequenceNrId", this.SequenceNrId);
			yield return new("templateId", this.TemplateId);
			yield return new("type", this.Type);
		}
	}
}
