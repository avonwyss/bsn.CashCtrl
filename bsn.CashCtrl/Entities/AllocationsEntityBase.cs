using System;
using System.Collections.Generic;
using System.Linq;

namespace bsn.CashCtrl.Entities {
	public abstract class AllocationsEntityBase: ExtensibleEntityBase {
		private int allocationCount;

		public int AllocationCount {
			get => Allocations?.Count ?? allocationCount;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set {
				Allocations = null;
				allocationCount = value;
			}
		}

		public List<AccountCostCenterAllocation> Allocations {
			get;
			set;
		} = new(0);

		public override IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (Allocations == null && allocationCount > 0) {
				throw new InvalidOperationException("The entity should have allocations, but these are not included in the entity.");
			}
			return base.ToParameters()
					.Append(new("allocations", Allocations));
		}
	}
}