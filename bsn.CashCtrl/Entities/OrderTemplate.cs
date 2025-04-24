using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace bsn.CashCtrl.Entities {
	public class OrderTemplate: FullEntityBase, IApiSerializable {
		private bool makeDefault;
		private bool? isDisplayLogo;
		private bool? isDisplayRecipientNr;
		private bool? isDisplayOrgAddressInWindow;
		private bool? isDisplayItemUnit;
		private bool? isDisplayItemPriceRounded;
		private bool? isDisplayResponsiblePerson;
		private bool? isDisplayPosNr;
		private bool? isDisplayItemArticleNr;
		private bool? isDisplayDocumentName;
		private bool? isDisplayPageNr;
		private bool? isDisplayZeroTax;
		private bool? isDisplayPayments;
		private bool? isDisplayItemTax;
		private bool? isOverwriteHtml;
		private bool? isOverwriteCss;
		private bool? isQrEmptyAmount;

		public string Name {
			get;
			set;
		}

		public string Html {
			get;
			set;
		}

		public string Css {
			get;
			set;
		}

		public string Footer {
			get;
			set;
		}

		public PageSize PageSize {
			get;
			set;
		} = PageSize.A4;

		public int? LetterPaperFileId {
			get;
			set;
		}

		public Attachment[] Attachments {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double LogoHeight {
			get;
			set;
		} = 2;

		public bool IsSystem {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsDefault {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsDisplayLogo {
			get => this.isDisplayLogo.GetValueOrDefault(true);
			set => this.isDisplayLogo = value;
		}

		public bool IsDisplayOrgAddress {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		} = true;

		public bool IsDisplayRecipientNr {
			get => this.isDisplayRecipientNr.GetValueOrDefault(true);
			set => this.isDisplayRecipientNr = value;
		}

		public bool IsDisplayOrgAddressInWindow {
			get => this.isDisplayOrgAddressInWindow.GetValueOrDefault(true);
			set => this.isDisplayOrgAddressInWindow = value;
		}

		public bool IsDisplayItemUnit {
			get => this.isDisplayItemUnit.GetValueOrDefault(true);
			set => this.isDisplayItemUnit = value;
		}

		public bool IsDisplayItemPriceRounded {
			get => this.isDisplayItemPriceRounded.GetValueOrDefault(true);
			set => this.isDisplayItemPriceRounded = value;
		}

		public bool IsDisplayResponsiblePerson {
			get => this.isDisplayResponsiblePerson.GetValueOrDefault(true);
			set => this.isDisplayResponsiblePerson = value;
		}

		public bool IsDisplayPosNr {
			get => this.isDisplayPosNr.GetValueOrDefault(true);
			set => this.isDisplayPosNr = value;
		}

		public bool IsDisplayItemArticleNr {
			get => this.isDisplayItemArticleNr.GetValueOrDefault(true);
			set => this.isDisplayItemArticleNr = value;
		}

		public bool IsDisplayDocumentName {
			get => this.isDisplayDocumentName.GetValueOrDefault(true);
			set => this.isDisplayDocumentName = value;
		}

		public bool IsDisplayPageNr {
			get => this.isDisplayPageNr.GetValueOrDefault(true);
			set => this.isDisplayPageNr = value;
		}

		public bool IsDisplayZeroTax {
			get => this.isDisplayZeroTax.GetValueOrDefault(false);
			set => this.isDisplayZeroTax = value;
		}

		public bool IsDisplayPayments {
			get => this.isDisplayPayments.GetValueOrDefault(true);
			set => this.isDisplayPayments = value;
		}

		public bool IsDisplayItemTax {
			get => this.isDisplayItemTax.GetValueOrDefault(false);
			set => this.isDisplayItemTax = value;
		}

		public bool IsOverwriteHtml {
			get => this.isOverwriteHtml.GetValueOrDefault(false);
			set => this.isOverwriteHtml = value;
		}

		public bool IsOverwriteCss {
			get => this.isOverwriteCss.GetValueOrDefault(false);
			set => this.isOverwriteCss = value;
		}

		public bool IsQrEmptyAmount {
			get => this.isQrEmptyAmount.GetValueOrDefault(false);
			set => this.isQrEmptyAmount = value;
		}

		public void MakeDefault() {
			this.makeDefault = true;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new("id", this.Id);
			}
			yield return new("name", this.Name);
			yield return new("css", this.Css);
			yield return new("footer", this.Footer);
			yield return new("html", this.Html);
			if (this.makeDefault) {
				yield return new("isDefault", true);
			}
			yield return new("isDisplayDocumentName", this.IsDisplayDocumentName);
			yield return new("isDisplayItemArticleNr", this.IsDisplayItemArticleNr);
			yield return new("isDisplayItemPriceRounded", this.IsDisplayItemPriceRounded);
			yield return new("isDisplayItemTax", this.IsDisplayItemTax);
			yield return new("isDisplayItemUnit", this.IsDisplayItemUnit);
			yield return new("isDisplayLogo", this.IsDisplayLogo);
			yield return new("isDisplayOrgAddressInWindow", this.IsDisplayOrgAddressInWindow);
			yield return new("isDisplayPageNr", this.IsDisplayPageNr);
			yield return new("isDisplayPayments", this.IsDisplayPayments);
			yield return new("isDisplayPosNr", this.IsDisplayPosNr);
			yield return new("isDisplayRecipientNr", this.IsDisplayRecipientNr);
			yield return new("isDisplayResponsiblePerson", this.IsDisplayResponsiblePerson);
			yield return new("isDisplayZeroTax", this.IsDisplayZeroTax);
			yield return new("isOverwriteCss", this.IsOverwriteCss);
			yield return new("isOverwriteHtml", this.IsOverwriteHtml);
			yield return new("isQrEmptyAmount", this.IsQrEmptyAmount);
			yield return new("letterPaperFileId", this.LetterPaperFileId);
			yield return new("logoHeight", this.LogoHeight);
			yield return new("pageSize", this.PageSize);
		}
	}
}
