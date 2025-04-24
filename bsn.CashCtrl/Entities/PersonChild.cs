using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class PersonChild: EntityBase, IApiSerializable {
		internal static bool IsNotEmpty(PersonChild child) {
			return !string.IsNullOrWhiteSpace(child.Name);
		}

		private int? age;

		public int PersonId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Name {
			get;
			set;
		}

		public DateTime DateBirth {
			get;
			set;
		}

		public DateTime? DateBenefitBegin {
			get;
			set;
		}

		public DateTime? DateBenefitEnd {
			get;
			set;
		}

		public DateTime? DateInEducation {
			get;
			set;
		}

		public int Age {
			get => this.age ?? (int)Math.Floor((DateTime.Now - this.DateBirth).TotalDays / 365.25);
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => this.age = value;
		}

		public string Notes {
			get;
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new("id", this.Id);
			}
			yield return new("name", this.Name);
			yield return new("dateBirth", this.DateBirth.ToCashCtrlString(true));
			if (this.DateBenefitBegin.HasValue) {
				yield return new("dateBenefitBegin", this.DateBenefitBegin.Value.ToCashCtrlString(true));
			}
			if (this.DateBenefitEnd.HasValue) {
				yield return new("dateBenefitEnd", this.DateBenefitEnd.Value.ToCashCtrlString(true));
			}
			if (this.DateInEducation.HasValue) {
				yield return new("dateInEducation", this.DateInEducation.Value.ToCashCtrlString(true));
			}
			yield return new("notes", this.Notes);
		}
	}
}
