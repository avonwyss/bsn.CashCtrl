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
			get => this.makeDefault || this.isDefault;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => this.isDefault = value;
		}

		public bool IsAuto {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new KeyValuePair<string, object>("id", this.Id);
			}
			yield return new KeyValuePair<string, object>("code", this.Code);
			yield return new KeyValuePair<string, object>("description", this.Description);
			if (this.makeDefault) {
				yield return new KeyValuePair<string, object>("isDefault", true);
			}
			if (this.saveRate) {
				yield return new KeyValuePair<string, object>("rate", this.Rate);
			}
		}

		public void MakeDefault() {
			this.makeDefault = true;
		}

		public void OverrideRate(double rate) {
			this.Rate = rate;
			this.saveRate = !double.IsNaN(rate);
		}
	}
}
