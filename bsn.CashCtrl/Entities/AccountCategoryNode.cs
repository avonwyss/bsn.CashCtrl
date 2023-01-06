using System;

namespace bsn.CashCtrl.Entities {
	public class AccountCategoryNode: AccountCategory {
		public AccountCategoryNode[] Data {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)] set;
		}

		public bool Leaf {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)] set;
		}
	}
}
