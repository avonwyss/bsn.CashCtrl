using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class PersonAddress: EntityBase, IApiSerializable {
		internal static bool IsNotEmpty(PersonAddress address) {
			return !(string.IsNullOrEmpty(address.Address) && string.IsNullOrEmpty(address.Zip) && string.IsNullOrEmpty(address.City) && string.IsNullOrEmpty(address.Country));
		}

		private bool? empty;
		private string address;
		private string zip;
		private string city;
		private string country;

		public int PersonId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public PersonAddressType Type {
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

		public string Country {
			get => this.country;
			set => this.country = CashCtrlClientExtensions.MapCountryToAlpha3(value);
		}

		public int Pos {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool Empty {
			get => this.empty.GetValueOrDefault(!IsNotEmpty(this));
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => this.empty = value;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			yield return new("type", this.Type);
			yield return new("address", this.Address);
			yield return new("city", this.City);
			yield return new("country", this.Country);
			yield return new("zip", this.Zip);
		}
	}
}
