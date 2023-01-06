using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class Currency: EntityBase, IApiSerializable {
		private bool isDefault;
		private bool makeDefault;
		private bool saveRate;

		public string Code {
			get;
			set;
		}

		public LocalizedString Description {
			get;
			set;
		}

		public double Rate {
			get;
			set;
		}

		public string Value {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Text {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public LocalizedString Index {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsDefault {
			get => makeDefault || isDefault;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => isDefault = value;
		}

		public bool IsAuto {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (Id > 0) {
				yield return new KeyValuePair<string, object>("id", Id);
			}
			yield return new KeyValuePair<string, object>("code", Code);
			yield return new KeyValuePair<string, object>("description", Description);
			if (makeDefault) {
				yield return new KeyValuePair<string, object>("isDefault", true);
			}
			if (saveRate) {
				yield return new KeyValuePair<string, object>("rate", Rate);
			}
		}

		public void MakeDefault() {
			makeDefault = true;
		}

		public void OverrideRate(double rate) {
			Rate = rate;
			saveRate = !double.IsNaN(rate);
		}
	}
}
