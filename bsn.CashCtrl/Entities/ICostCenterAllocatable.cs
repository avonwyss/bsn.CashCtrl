using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public interface ICostCenterAllocatable {
		int AllocationCount {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		CloneableList<AccountCostCenterAllocation> Allocations {
			get;
			set;
		}
	}
}
