using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace bsn.CashCtrl.Entities {
	public class OrderTemplate: EntityBase, IApiSerializable {
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
			get => isDisplayLogo.GetValueOrDefault(true);
			set => isDisplayLogo = value;
		}

		public bool IsDisplayOrgAddress {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		} = true;

		public bool IsDisplayRecipientNr {
			get => isDisplayRecipientNr.GetValueOrDefault(true);
			set => isDisplayRecipientNr = value;
		}

		public bool IsDisplayOrgAddressInWindow {
			get => isDisplayOrgAddressInWindow.GetValueOrDefault(true);
			set => isDisplayOrgAddressInWindow = value;
		}

		public bool IsDisplayItemUnit {
			get => isDisplayItemUnit.GetValueOrDefault(true);
			set => isDisplayItemUnit = value;
		}

		public bool IsDisplayItemPriceRounded {
			get => isDisplayItemPriceRounded.GetValueOrDefault(true);
			set => isDisplayItemPriceRounded = value;
		}

		public bool IsDisplayResponsiblePerson {
			get => isDisplayResponsiblePerson.GetValueOrDefault(true);
			set => isDisplayResponsiblePerson = value;
		}

		public bool IsDisplayPosNr {
			get => isDisplayPosNr.GetValueOrDefault(true);
			set => isDisplayPosNr = value;
		}

		public bool IsDisplayItemArticleNr {
			get => isDisplayItemArticleNr.GetValueOrDefault(true);
			set => isDisplayItemArticleNr = value;
		}

		public bool IsDisplayDocumentName {
			get => isDisplayDocumentName.GetValueOrDefault(true);
			set => isDisplayDocumentName = value;
		}

		public bool IsDisplayPageNr {
			get => isDisplayPageNr.GetValueOrDefault(true);
			set => isDisplayPageNr = value;
		}

		public bool IsDisplayZeroTax {
			get => isDisplayZeroTax.GetValueOrDefault(false);
			set => isDisplayZeroTax = value;
		}

		public bool IsDisplayPayments {
			get => isDisplayPayments.GetValueOrDefault(true);
			set => isDisplayPayments = value;
		}

		public bool IsDisplayItemTax {
			get => isDisplayItemTax.GetValueOrDefault(false);
			set => isDisplayItemTax = value;
		}

		public bool IsOverwriteHtml {
			get => isOverwriteHtml.GetValueOrDefault(false);
			set => isOverwriteHtml = value;
		}

		public bool IsOverwriteCss {
			get => isOverwriteCss.GetValueOrDefault(false);
			set => isOverwriteCss = value;
		}

		public bool IsQrEmptyAmount {
			get => isQrEmptyAmount.GetValueOrDefault(false);
			set => isQrEmptyAmount = value;
		}

		public void MakeDefault() {
			makeDefault = true;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (Id > 0) {
				yield return new("id", Id);
			}
			yield return new("name", Name);
			yield return new("css", Css);
			yield return new("footer", Footer);
			yield return new("html", Html);
			if (makeDefault) {
				yield return new("isDefault", true);
			}
			yield return new("isDisplayDocumentName", IsDisplayDocumentName);
			yield return new("isDisplayItemArticleNr", IsDisplayItemArticleNr);
			yield return new("isDisplayItemPriceRounded", IsDisplayItemPriceRounded);
			yield return new("isDisplayItemTax", IsDisplayItemTax);
			yield return new("isDisplayItemUnit", IsDisplayItemUnit);
			yield return new("isDisplayLogo", IsDisplayLogo);
			yield return new("isDisplayOrgAddressInWindow", IsDisplayOrgAddressInWindow);
			yield return new("isDisplayPageNr", IsDisplayPageNr);
			yield return new("isDisplayPayments", IsDisplayPayments);
			yield return new("isDisplayPosNr", IsDisplayPosNr);
			yield return new("isDisplayRecipientNr", IsDisplayRecipientNr);
			yield return new("isDisplayResponsiblePerson", IsDisplayResponsiblePerson);
			yield return new("isDisplayZeroTax", IsDisplayZeroTax);
			yield return new("isOverwriteCss", IsOverwriteCss);
			yield return new("isOverwriteHtml", IsOverwriteHtml);
			yield return new("isQrEmptyAmount", IsQrEmptyAmount);
			yield return new("letterPaperFileId", LetterPaperFileId);
			yield return new("logoHeight", LogoHeight);
			yield return new("pageSize", PageSize);
		}
	}
}