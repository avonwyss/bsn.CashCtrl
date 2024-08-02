using System;
using System.Collections.Generic;
using System.Linq;

namespace bsn.CashCtrl.Entities {
	public class Person: ExtensibleEntityBase {
		private int? sequenceNumberId;

		public int? CategoryId {
			get;
			set;
		}

		public int? ThumbnailFileId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string CategoryDisplay {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public List<PersonContact> Contacts {
			get;
			set;
		} = new List<PersonContact>(0);

		public List<PersonAddress> Addresses {
			get;
			set;
		} = new List<PersonAddress>(0);

		public LocalizedString TitleName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? TitleId {
			get;
			set;
		}

		public string TitleSentence {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public PersonGender Gender {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Nr {
			get;
			set;
		}

		public string Name {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
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

		public string Company {
			get;
			set;
		}

		public string Position {
			get;
			set;
		}

		public string Industry {
			get;
			set;
		}

		public string Department {
			get;
			set;
		}

		public string Language {
			get;
			set;
		}

		public string BankData {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Iban {
			get;
			set;
		}

		public string Bic {
			get;
			set;
		}

		public string VatUid {
			get;
			set;
		}

		public DateTime? DateBirth {
			get;
			set;
		}

		public double? DiscountPercentage {
			get;
			set;
		}

		public double? DiscountInherited {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double? DiscountEffective {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string GetContactAddress(PersonContactType type) {
			return Contacts.FirstOrDefault(t => t.Type == type)?.Address;
		}

		public void SetContactAddress(PersonContactType type, string address, bool replaceOfSameType = true) {
			var i = 0;
			while (i < Contacts.Count) {
				if (Contacts[i].Type == type) {
					if (!string.IsNullOrEmpty(address)) {
						Contacts[i].Address = address;
						i++;
					}
					if (replaceOfSameType) {
						for (var j = Contacts.Count-1; j >= i; j--) {
							if (Contacts[j].Type == type) {
								Contacts.RemoveAt(j);
							}
						}
					}
					break;
				}
				i++;
			}
			Contacts.Add(new PersonContact() {
					Type = type,
					Address = address
			});
		}

		public string EmailWork {
			get => GetContactAddress(PersonContactType.EmailWork);
			set => SetContactAddress(PersonContactType.EmailWork, value);
		}

		public string EmailPrivate {
			get => GetContactAddress(PersonContactType.EmailPrivate);
			set => SetContactAddress(PersonContactType.EmailPrivate, value);
		}

		public string PhoneWork {
			get => GetContactAddress(PersonContactType.PhoneWork);
			set => SetContactAddress(PersonContactType.PhoneWork, value);
		}

		public string PhonePrivate {
			get => GetContactAddress(PersonContactType.PhonePrivate);
			set => SetContactAddress(PersonContactType.PhonePrivate, value);
		}

		public string MobileWork {
			get => GetContactAddress(PersonContactType.MobileWork);
			set => SetContactAddress(PersonContactType.MobileWork, value);
		}

		public string MobilePrivate {
			get => GetContactAddress(PersonContactType.MobilePrivate);
			set => SetContactAddress(PersonContactType.MobilePrivate, value);
		}

		public string Url {
			get => GetContactAddress(PersonContactType.Website);
			set => SetContactAddress(PersonContactType.Website, value);
		}

		public PersonAddress GetAddress(PersonAddressType type = PersonAddressType.Main) {
			var result = Addresses.FirstOrDefault(a => a.Type == type);
			if (result == null) {
				result = new PersonAddress() {
						Type = type
				};
				Addresses.Add(result);
			}
			return result;
		}

		public string Address {
			get => GetAddress().Address;
			set => GetAddress().Address = value;
		}

		public string Zip {
			get => GetAddress().Zip;
			set => GetAddress().Zip = value;
		}

		public string City {
			get => GetAddress().City;
			set => GetAddress().City = value;
		}

		public string Country {
			get => GetAddress().Country;
			set => GetAddress().Country = value;
		}

		public int? SuperiorId {
			get;
			set;
		}

		public string SuperiorName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public PersonColor? Color {
			get;
			set;
		}

		public LocalizedString AltName {
			get;
			set;
		}

		public bool IsInactive {
			get;
			set;
		}

		public int? SequenceNumberId {
			[Obsolete(CashCtrlClient.EntityFieldMissing, true)]
			get => sequenceNumberId;
			set => sequenceNumberId = value;
		}

		protected override IEnumerable<KeyValuePair<string, object>> ToParametersInternal() {
			yield return new("company", Company);
			yield return new("firstName", FirstName);
			yield return new("lastName", LastName);
			yield return new("addresses", Addresses.Where(PersonAddress.IsNotEmpty));
			yield return new("altName", AltName);
			yield return new("bic", Bic);
			yield return new("categoryId", CategoryId);
			yield return new("color", Color);
			yield return new("contacts", Contacts.Where(PersonContact.IsNotEmpty));
			yield return new("dateBirth", DateBirth);
			yield return new("department", Department);
			yield return new("discountPercentage", DiscountPercentage);
			yield return new("iban", Iban);
			yield return new("industry", Industry);
			yield return new("isInactive", IsInactive);
			yield return new("language", Language);
			if (!string.IsNullOrEmpty(Nr)) {
				yield return new("nr", Nr);
			}
			yield return new("position", Position);
			yield return new("sequenceNumberId", sequenceNumberId);
			yield return new("superiorId", SuperiorId);
			yield return new("titleId", TitleId);
			yield return new("vatUid", VatUid);
		}
	}
}

