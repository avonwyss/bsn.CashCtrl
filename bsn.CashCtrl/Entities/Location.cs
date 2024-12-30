using System;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;

namespace bsn.CashCtrl.Entities {
	public class Location: EntityBase, IApiSerializable {
		public string Name {
			get;
			set;
		}

		public LocationType Type {
			get;
			set;
		}

		public int? LogoFileId {
			get;
			set;
		}

		public Attachment[] Attachments {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string OrgName {
			get;
			set;
		}

		public string Address {
			get;
			set;
		}

		public string Zip {
			get;
			set;
		}

		public string City {
			get;
			set;
		}

		public string Country {
			get;
			set;
		}

		public string VatUid {
			get;
			set;
		}

		public string Iban {
			get;
			set;
		}

		public string QrIban {
			get;
			set;
		}

		public string QrFirstDigits {
			get;
			set;
		}

		public string Bic {
			get;
			set;
		}

		public JToken BankData {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Footer {
			get;
			set;
		}

		public string FullAddress {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string FullAddressCsv {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Value {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Text {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string ListCls {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsInactive {
			get;
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new("id", this.Id);
			}
			yield return new("name", this.Name);
			yield return new("address", this.Address);
			yield return new("bic", this.Bic);
			yield return new("city", this.City);
			yield return new("country", this.Country);
			yield return new("footer", this.Footer);
			yield return new("iban", this.Iban);
			yield return new("isInactive", this.IsInactive);
			yield return new("logoFileId", this.LogoFileId);
			yield return new("orgName", this.OrgName);
			yield return new("qrFirstDigits", this.QrFirstDigits);
			yield return new("qrIban", this.QrIban);
			yield return new("type", this.Type);
			yield return new("vatUid", this.VatUid);
			yield return new("zip", this.Zip);
		}
	}
}
