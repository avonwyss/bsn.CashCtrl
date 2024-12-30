using System;

namespace bsn.CashCtrl.Entities {
	public class AccountCostCenterCategoryNode: AccountCostCenterCategory {
		public AccountCostCenterCategoryNode[] Data {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool Leaf {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}
	}
}
