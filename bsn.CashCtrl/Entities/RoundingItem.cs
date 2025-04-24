using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsn.CashCtrl.Entities {
	public class RoundingItem: FullEntityBase, IApiSerializable {
		public int AccountId {
			get;
			set;
		}

		public LocalizedString Name {
			get;
			set;
		}

		public double Rounding {
			get;
			set;
		}

		public RoundingMode Mode {
			get;
			set;
		} = RoundingMode.HalfUp;

		public string Text {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Value {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool Referenced {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new("id", this.Id);
			}
			yield return new("accountId", this.AccountId);
			yield return new("name", this.Name);
			yield return new("rounding", this.Rounding);
			yield return new("mode", this.Mode);
		}
	}
}
