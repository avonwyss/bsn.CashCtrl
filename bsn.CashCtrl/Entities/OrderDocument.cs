using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class OrderDocument: IApiSerializable {
		public int OrderId {
			get;
			set;
		}

		public int TemplateId {
			get;
			set;
		}

		public int? RecipientAddressId {
			get;
			set;
		}

		public int OrgLocationId {
			get;
			set;
		}

		public string RecipientAddress {
			get;
			set;
		}

		public string OrgAddress {
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

		public string MailTo {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string MailFrom {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string MailReplyTo {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string MailCc {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string MailBcc {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string MailSubject {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string MailText {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Language {
			get;
			set;
		}

		public string OrgAddressCsv {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string RecipientAddressCsv {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int AssociateId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Nr {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int CategoryId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? FileId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int SentStatusId {
			get;
			set;
		}

		public LocalizedString NameSingular {
			get;
			set;
		}

		public bool IsDisplayPrices {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsDisplayItemGross {
			get;
			set;
		}

		public bool IsSwitchRecipient {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsFileReplacement {
			get;
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			yield return new("id", this.OrderId);
			yield return new("fileId", this.FileId);
			yield return new("footer", this.Footer);
			yield return new("header", this.Header);
			yield return new("isDisplayItemGross", this.IsDisplayItemGross);
			yield return new("isFileReplacement", this.IsFileReplacement);
			yield return new("language", this.Language);
			yield return new("orgAddress", this.OrgAddress);
			yield return new("orgLocationId", this.OrgLocationId);
			yield return new("recipientAddress", this.RecipientAddress);
			yield return new("recipientAddressId", this.RecipientAddressId);
			yield return new("templateId", this.TemplateId);
		}
	}
}
