using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class OrderCategoryStatus: FullEntityBase, IApiSerializable {
		public int CategoryId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string ActionId {
			get;
			set;
		}

		public LocalizedString Name {
			get;
			set;
		}

		public OrderStatusIcon Icon {
			get;
			set;
		}

		public int Pos {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

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

		public string IconCls {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsBook {
			get;
			set;
		}

		public bool IsRemoveStock {
			get;
			set;
		}

		public bool IsAddStock {
			get;
			set;
		}

		public bool IsClosed {
			get;
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			yield return new("icon", this.Icon);
			yield return new("name", this.Name);
			yield return new("actionId", this.ActionId);
			yield return new("isAddStock", this.IsAddStock);
			yield return new("isBook", this.IsBook);
			yield return new("isClosed", this.IsClosed);
			yield return new("isRemoveStock", this.IsRemoveStock);
		}
	}
}
