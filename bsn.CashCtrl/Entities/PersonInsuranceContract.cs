using System;
using System.Collections.Generic;
using System.Globalization;

namespace bsn.CashCtrl.Entities {
	public class PersonInsuranceContract: EntityBase, IApiSerializable {
		public int PersonId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int TypeId {
			get;
			set;
		}

		public LocalizedString TypeName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string ContractNr {
			get;
			set;
		}

		public string SubNr {
			get;
			set;
		}

		public int Pos {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Name {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string City {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string InsuranceNr {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Zip {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string MemberNr {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new("id", this.Id);
			}
			yield return new("typeId", this.TypeId.ToString(CultureInfo.InvariantCulture));
			yield return new("contactNr", this.ContractNr);
			yield return new("subNr", this.SubNr);
		}
	}
}
