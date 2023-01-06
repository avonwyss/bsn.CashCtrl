using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class OrderCategoryStatus: EntityBase, IApiSerializable {
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
			yield return new("icon", Icon);
			yield return new("name", Name);
			yield return new("actionId", ActionId);
			yield return new("isAddStock", IsAddStock);
			yield return new("isBook", IsBook);
			yield return new("isClosed", IsClosed);
			yield return new("isRemoveStock", IsRemoveStock);
		}
	}
}