using System;

namespace bsn.CashCtrl.Entities {
	public class EntityItems<T> {
		public T[] Items {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int Id {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}
	}
}
