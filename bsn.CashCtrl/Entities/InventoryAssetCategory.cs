using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class InventoryAssetCategory: EntityBase, IApiSerializable {
		private int? sequenceNrId;

		public LocalizedString Name {
			get;
			set;
		}

		public InventoryType Type {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? ParentId {
			get;
			set;
		}

		public List<AccountCostCenterAllocation> Allocations {
			get;
			set;
		} = new(0);

		public int? PurchaseAccountId {
			get;
			set;
		}

		public int? SalesAccountId {
			get;
			set;
		}

		public int? SequenceNrId {
			[Obsolete(CashCtrlClient.EntityFieldMissing, false)]
			get => sequenceNrId;
			set => sequenceNrId = value;
		}

		public int? SequenceNrIdInherited {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (Id > 0) {
				yield return new KeyValuePair<string, object>("id", Id);
			}
			yield return new KeyValuePair<string, object>("name", Name);
			yield return new KeyValuePair<string, object>("parentId", ParentId);
			yield return new KeyValuePair<string, object>("allocations", (IEnumerable<AccountCostCenterAllocation>)Allocations ?? Array.Empty<AccountCostCenterAllocation>());
			yield return new KeyValuePair<string, object>("purchaseAccountId", PurchaseAccountId);
			yield return new KeyValuePair<string, object>("salesAccountId", SalesAccountId);
			yield return new KeyValuePair<string, object>("sequenceNrId", sequenceNrId);
		}
	}
}
