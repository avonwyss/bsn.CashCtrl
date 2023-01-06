using System;
using System.Collections.Generic;
using System.Linq;

namespace bsn.CashCtrl.Entities {
	public class OrderCategory: EntityBase, IApiSerializable {
		public int AccountId {
			get;
			set;
		}

		public int? CurrencyId {
			get;
			set;
		}

		public List<OrderCategoryStatus> Status {
			get;
			set;
		} = new(0);

		public List<OrderCategoryBookTemplate> BookTemplates {
			get;
			set;
		} = new(0);

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
			var template = BookTemplates.Single(bt => bt.Id == templateId);
			bookEntry.TemplateId = template.Id;
			if (template.AccountId.HasValue) {
				bookEntry.AccountId = template.AccountId.Value;
			}
			bookEntry.Description = template.Name.ToString(language);
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (base.Id > 0) {
				yield return new("id", base.Id);
			}
			yield return new("accountId", AccountId);
			yield return new("namePlural", NamePlural);
			yield return new("nameSingular", NameSingular);
			yield return new("status", Status);
			yield return new("addressType", AddressType);
			yield return new("bookTemplates", BookTemplates);
			yield return new("bookType", BookType);
			yield return new("currencyId", CurrencyId);
			yield return new("dueDays", DueDays);
			yield return new("fileId", FileId);
			yield return new("footer", Footer);
			yield return new("hasDueDays", HasDueDays);
			yield return new("header", Header);
			yield return new("isDisplayItemGross", IsDisplayItemGross);
			yield return new("isDisplayPrices", IsDisplayPrices);
			yield return new("isInactive", IsInactive);
			yield return new("isSwitchRecipient", IsSwitchRecipient);
			yield return new("mail", Mail);
			yield return new("responsiblePersonId", ResponsiblePersonId);
			yield return new("roundingId", RoundingId);
			yield return new("sentStatusId", SentStatusId);
			yield return new("sequenceNrId", SequenceNrId);
			yield return new("templateId", TemplateId);
			yield return new("type", Type);
		}
	}
}
