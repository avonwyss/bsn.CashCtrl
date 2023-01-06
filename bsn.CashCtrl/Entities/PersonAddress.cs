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
			get => address;
			set => address = value;
		}

		public string Zip {
			get => zip;
			set => zip = value;
		}

		public string City {
			get => city;
			set => city = value;
		}

		public string Country {
			get => country;
			set => country = CashCtrlClientExtensions.MapCountryToAlpha3(value);
		}

		public int Pos {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool Empty {
			get => empty.GetValueOrDefault(!IsNotEmpty(this));
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => empty = value;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			yield return new("type", Type);
			yield return new("address", Address);
			yield return new("city", City);
			yield return new("country", Country);
			yield return new("zip", Zip);
		}
	}
}