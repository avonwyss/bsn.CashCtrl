using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class PersonAddress: EntityBase, IApiSerializable {
		internal static bool IsNotEmpty(PersonAddress address) {
			return !(string.IsNullOrEmpty(address.Address) && string.IsNullOrEmpty(address.Zip) && string.IsNullOrEmpty(address.City) && string.IsNullOrEmpty(address.Country));
		}

		private string address;
		private string city;
		private string country;
		private string zip;

		public int PersonId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? TitleId {
			get;
			set;
		}

		public PersonAddressType Type {
			get;
			set;
		}

		public string Company {
			get;
			set;
		}

		public string FirstName {
			get;
			set;
		}

		public string LastName {
			get;
			set;
		}

		public string Address {
			get => this.address;
			set => this.address = value;
		}

		public string Zip {
			get => this.zip;
			set => this.zip = value;
		}

		public string City {
			get => this.city;
			set => this.city = value;
		}

		public string Canton {
			get;
			set;
		}

		public string Country {
			get => this.country;
			set => this.country = CashCtrlClientExtensions.MapCountryToAlpha3(value);
		}

		public int Pos {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string CantonCode {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string CountryCode2 {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string CountryCode3 {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string CompanyForAddress {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string FirstNameForAddress {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string LastNameForAddress {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string StreetName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string StreetNumber {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsHideCompany {
			get;
			set;
		}

		public bool IsHideName {
			get;
			set;
		}

		public bool Empty => !IsNotEmpty(this);

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new("id", this.Id);
			}
			yield return new("titleId", this.TitleId);
			yield return new("type", this.Type);
			yield return new("company", this.Company);
			yield return new("firstName", this.FirstName);
			yield return new("lastName", this.LastName);
			yield return new("isHideCompany", this.IsHideCompany);
			yield return new("isHideName", this.IsHideName);
			yield return new("address", this.Address);
			yield return new("zip", this.Zip);
			yield return new("city", this.City);
			yield return new("canton", this.Canton);
			yield return new("country", this.Country);
		}
	}
}
