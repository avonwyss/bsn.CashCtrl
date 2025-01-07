using System;
using System.Collections.Generic;
using System.Linq;

namespace bsn.CashCtrl.Entities {
	public abstract class AllocationsEntityBase: ExtensibleEntityBase, ICostCenterAllocatable {
		// ReSharper disable once FieldCanBeMadeReadOnly.Local - Must be read-write for cloning
		private VirtualList<AccountCostCenterAllocation> allocations = new();

		public override bool Partial => base.Partial || this.allocations.HasVirtualValues;

		public int AllocationCount {
			get => this.allocations.Count;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => this.allocations.Count = value;
		}

		public IList<AccountCostCenterAllocation> Allocations {
			get => this.allocations;
			set => this.allocations.MakeSameAs(value);
		}

		public override IEnumerable<KeyValuePair<string, object>> ToParameters() {
			foreach (var pair in base.ToParameters()) {
				yield return pair;
			}
			yield return new("allocations", this.Allocations);
		}
	}
}
