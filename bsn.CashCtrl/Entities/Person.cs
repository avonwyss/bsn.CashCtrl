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
			return this.Contacts.FirstOrDefault(t => t.Type == type)?.Address;
		}

		public void SetContactAddress(PersonContactType type, string address, bool replaceOfSameType = true) {
			var i = 0;
			while (i < this.Contacts.Count) {
				if (this.Contacts[i].Type == type) {
					if (!string.IsNullOrEmpty(address)) {
						this.Contacts[i].Address = address;
						i++;
					}
					if (replaceOfSameType) {
						for (var j = this.Contacts.Count-1; j >= i; j--) {
							if (this.Contacts[j].Type == type) {
								this.Contacts.RemoveAt(j);
							}
						}
					}
					break;
				}
				i++;
			}
			this.Contacts.Add(new PersonContact() {
					Type = type,
					Address = address
			});
		}

		public string EmailWork {
			get => this.GetContactAddress(PersonContactType.EmailWork);
			set => this.SetContactAddress(PersonContactType.EmailWork, value);
		}

		public string EmailPrivate {
			get => this.GetContactAddress(PersonContactType.EmailPrivate);
			set => this.SetContactAddress(PersonContactType.EmailPrivate, value);
		}

		public string PhoneWork {
			get => this.GetContactAddress(PersonContactType.PhoneWork);
			set => this.SetContactAddress(PersonContactType.PhoneWork, value);
		}

		public string PhonePrivate {
			get => this.GetContactAddress(PersonContactType.PhonePrivate);
			set => this.SetContactAddress(PersonContactType.PhonePrivate, value);
		}

		public string MobileWork {
			get => this.GetContactAddress(PersonContactType.MobileWork);
			set => this.SetContactAddress(PersonContactType.MobileWork, value);
		}

		public string MobilePrivate {
			get => this.GetContactAddress(PersonContactType.MobilePrivate);
			set => this.SetContactAddress(PersonContactType.MobilePrivate, value);
		}

		public string Url {
			get => this.GetContactAddress(PersonContactType.Website);
			set => this.SetContactAddress(PersonContactType.Website, value);
		}

		public PersonAddress GetAddress(PersonAddressType type = PersonAddressType.Main, bool createIfNotPresent = false) {
			var result = this.Addresses.FirstOrDefault(a => a.Type == type);
			if (result == null && createIfNotPresent) {
				result = new PersonAddress() {
						Type = type
				};
				this.Addresses.Add(result);
			}
			return result;
		}

		public string Address {
			get => this.GetAddress(PersonAddressType.Main, false)?.Address;
			set => this.GetAddress(PersonAddressType.Main, true).Address = value;
		}

		public string Zip {
			get => this.GetAddress(PersonAddressType.Main, false)?.Zip;
			set => this.GetAddress(PersonAddressType.Main, true).Zip = value;
		}

		public string City {
			get => this.GetAddress(PersonAddressType.Main, false)?.City;
			set => this.GetAddress(PersonAddressType.Main, true).City = value;
		}

		public string Country {
			get => this.GetAddress(PersonAddressType.Main, false)?.Country;
			set => this.GetAddress(PersonAddressType.Main, true).Country = value;
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
			get => this.sequenceNumberId;
			set => this.sequenceNumberId = value;
		}

		protected override IEnumerable<KeyValuePair<string, object>> ToParametersInternal() {
			yield return new("company", this.Company);
			yield return new("firstName", this.FirstName);
			yield return new("lastName", this.LastName);
			yield return new("addresses", this.Addresses.Where(PersonAddress.IsNotEmpty));
			yield return new("altName", this.AltName);
			yield return new("bic", this.Bic);
			yield return new("categoryId", this.CategoryId);
			yield return new("color", this.Color);
			yield return new("contacts", this.Contacts.Where(PersonContact.IsNotEmpty));
			yield return new("dateBirth", this.DateBirth);
			yield return new("department", this.Department);
			yield return new("discountPercentage", this.DiscountPercentage);
			yield return new("iban", this.Iban);
			yield return new("industry", this.Industry);
			yield return new("isInactive", this.IsInactive);
			yield return new("language", this.Language);
			if (!string.IsNullOrEmpty(this.Nr)) {
				yield return new("nr", this.Nr);
			}
			yield return new("position", this.Position);
			yield return new("sequenceNumberId", this.sequenceNumberId);
			yield return new("superiorId", this.SuperiorId);
			yield return new("titleId", this.TitleId);
			yield return new("vatUid", this.VatUid);
		}
	}
}

