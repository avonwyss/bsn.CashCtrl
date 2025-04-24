using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class PersonBankAccount: EntityBase, IApiSerializable {
		internal static bool IsNotEmpty(PersonBankAccount account) {
			return !string.IsNullOrWhiteSpace(account.Iban);
		}

		public int Pos {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int PersonId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? CurrencyId {
			get;
			set;
		}

		public PersonBankAccountType Type {
			get;
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

		public string Notes {
			get;
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new("id", this.Id);
			}
			yield return new ("type", this.Type);
			yield return new ("iban", this.Iban);
			yield return new ("bic", this.Bic);
			if (this.CurrencyId.HasValue) {
				yield return new("currencyId", this.CurrencyId);
			}
			yield return new("notes", this.Notes);
		}
	}
}
