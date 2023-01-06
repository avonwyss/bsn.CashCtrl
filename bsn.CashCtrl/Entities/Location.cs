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
			if (Id > 0) {
				yield return new KeyValuePair<string, object>("id", Id);
			}
			yield return new KeyValuePair<string, object>("name", Name);
			yield return new KeyValuePair<string, object>("address", Address);
			yield return new KeyValuePair<string, object>("bic", Bic);
			yield return new KeyValuePair<string, object>("city", City);
			yield return new KeyValuePair<string, object>("country", Country);
			yield return new KeyValuePair<string, object>("footer", Footer);
			yield return new KeyValuePair<string, object>("iban", Iban);
			yield return new KeyValuePair<string, object>("isInactive", IsInactive);
			yield return new KeyValuePair<string, object>("logoFileId", LogoFileId);
			yield return new KeyValuePair<string, object>("orgName", OrgName);
			yield return new KeyValuePair<string, object>("qrFirstDigits", QrFirstDigits);
			yield return new KeyValuePair<string, object>("qrIban", QrIban);
			yield return new KeyValuePair<string, object>("type", Type);
			yield return new KeyValuePair<string, object>("vatUid", VatUid);
			yield return new KeyValuePair<string, object>("zip", Zip);
		}
	}
}
