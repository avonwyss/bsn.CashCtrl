using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace bsn.CashCtrl.Entities {
	public class Person: ExtensibleEntityBase {
		// ReSharper disable once FieldCanBeMadeReadOnly.Local - Must be read-write for cloning
		private VirtualList<PersonAddress> addresses = new();

		// ReSharper disable once FieldCanBeMadeReadOnly.Local - Must be read-write for cloning
		private VirtualList<PersonBankAccount> bankAccounts = new();

		// ReSharper disable once FieldCanBeMadeReadOnly.Local - Must be read-write for cloning
		private VirtualList<PersonChild> children = new();

		// ReSharper disable once FieldCanBeMadeReadOnly.Local - Must be read-write for cloning
		private VirtualList<PersonContact> contacts = new();

		// ReSharper disable once FieldCanBeMadeReadOnly.Local - Must be read-write for cloning
		private VirtualList<PersonInsuranceContract> insuranceContracts = new();
		private int? sequenceNumberId;

		// ReSharper disable once FieldCanBeMadeReadOnly.Local - Must be read-write for cloning
		private VirtualList<PersonServicePeriod> servicePeriods = new();
		private LocalizedString titleName;

		public int? CategoryId {
			get;
			set;
		}

		public int? UserId {
			get;
			set;
		}

		public int? ThumbnailFileId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public LocalizedString CategoryDisplay {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? CertificateTemplateId {
			get;
			set;
		}

		[JsonConverter(typeof(JsonStringConverter))]
		public JObject CertificateValues {
			get;
			set;
		}

		public IList<PersonContact> Contacts {
			get => this.contacts;
			set => this.contacts.MakeSameAs(value);
		}

		public IList<PersonAddress> Addresses {
			get => this.addresses;
			set => this.addresses.MakeSameAs(value);
		}

		public IList<PersonBankAccount> BankAccounts {
			get => this.bankAccounts;
			set => this.bankAccounts.MakeSameAs(value);
		}

		public IList<PersonChild> Children {
			get => this.children;
			set => this.children.MakeSameAs(value);
		}

		public int ChildrenCount {
			get => this.children.Count;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => this.children.Count = value;
		}

		public IList<PersonInsuranceContract> InsuranceContracts {
			get => this.insuranceContracts;
			set => this.insuranceContracts.MakeSameAs(value);
		}

		public IList<PersonServicePeriod> ServicePeriods {
			get => this.servicePeriods;
			set => this.servicePeriods.MakeSameAs(value);
		}

		public LocalizedString TitleName {
			get => this.titleName;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => this.titleName = value;
		}

		public LocalizedString Title {
			get => this.titleName;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => this.titleName = value;
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

		public string IconCls {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Name {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string AbbreviatedName {
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

		public string Ssn {
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
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Bic {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
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

		public bool IsCustomer {
			get;
			set;
		}

		public bool IsVendor {
			get;
			set;
		}

		public bool IsEmployee {
			get;
			set;
		}

		public bool IsInsurance {
			get;
			set;
		}

		public bool IsFamily {
			get;
			set;
		}

		public bool IsInactive {
			get;
			set;
		}

		public bool IsAutoFillResponsiblePerson {
			get;
			set;
		}

		public int? SequenceNumberId {
			[Obsolete(CashCtrlClient.EntityFieldMissing, true)]
			get => this.sequenceNumberId;
			set => this.sequenceNumberId = value;
		}

		public string InsuranceNr {
			get;
			set;
		}

		public string InsuranceMemberNr {
			get;
			set;
		}

		public int? LocationId {
			get;
			set;
		}

		public string LocationName {
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
						for (var j = this.Contacts.Count - 1; j >= i; j--) {
							if (this.Contacts[j].Type == type) {
								this.Contacts.RemoveAt(j);
							}
						}
					}
					return;
				}
				i++;
			}
			this.Contacts.Add(new() {
					Type = type,
					Address = address
			});
		}

		public PersonAddress GetAddress(PersonAddressType type = PersonAddressType.Main, bool createIfNotPresent = false) {
			var result = this.Addresses.FirstOrDefault(a => a.Type == type);
			if (result == null && createIfNotPresent) {
				result = new() {
						Type = type
				};
				this.Addresses.Add(result);
			}
			return result;
		}

		public override IEnumerable<KeyValuePair<string, object>> ToParameters() {
			foreach (var pair in base.ToParameters()) {
				yield return pair;
			}
			yield return new("company", this.Company);
			yield return new("firstName", this.FirstName);
			yield return new("lastName", this.LastName);
			yield return new("addresses", this.Addresses.Where(PersonAddress.IsNotEmpty));
			yield return new("altName", this.AltName);
			yield return new("bankAccounts", this.BankAccounts.Where(PersonBankAccount.IsNotEmpty));
			yield return new("bankData", this.BankData);
			yield return new("categoryId", this.CategoryId);
			if (this.IsEmployee) {
				yield return new("certificateTemplateId", this.CertificateTemplateId);
				yield return new("certificateValues", this.CertificateValues);
				yield return new("locationId", this.LocationId);
			}
			if (this.IsEmployee || this.IsFamily) {
				yield return new("children", this.Children.Where(PersonChild.IsNotEmpty));
			}
			yield return new("color", this.Color);
			yield return new("contacts", this.Contacts.Where(PersonContact.IsNotEmpty));
			yield return new("dateBirth", this.DateBirth);
			yield return new("department", this.Department);
			yield return new("discountPercentage", this.DiscountPercentage);
			yield return new("industry", this.Industry);
			if (this.IsInsurance) {
				yield return new("insuranceContracts", this.InsuranceContracts);
				yield return new("insuranceMemberNr", this.InsuranceMemberNr);
				yield return new("insuranceNr", this.InsuranceNr);
			}
			yield return new("isAutoFillResponsiblePerson", this.IsAutoFillResponsiblePerson);
			yield return new("isCustomer", this.IsCustomer);
			yield return new("isEmployee", this.IsEmployee);
			yield return new("isFamily", this.IsFamily);
			yield return new("isInactive", this.IsInactive);
			yield return new("isInsurance", this.IsInsurance);
			yield return new("isVendor", this.IsVendor);
			yield return new("language", this.Language);
			if (!string.IsNullOrEmpty(this.Nr)) {
				yield return new("nr", this.Nr);
			}
			yield return new("position", this.Position);
			yield return new("sequenceNumberId", this.sequenceNumberId);
			yield return new("servicePeriods", this.ServicePeriods);
			yield return new("ssn", this.Ssn);
			yield return new("superiorId", this.SuperiorId);
			yield return new("titleId", this.TitleId);
			yield return new("userId", this.UserId);
			yield return new("vatUid", this.VatUid);
		}
	}
}
