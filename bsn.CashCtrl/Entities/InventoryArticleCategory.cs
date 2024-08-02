using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class InventoryArticleCategory: EntityBase, IApiSerializable {
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
			get => this.sequenceNrId;
			set => this.sequenceNrId = value;
		}

		public int? SequenceNrIdInherited {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new KeyValuePair<string, object>("id", this.Id);
			}
			yield return new KeyValuePair<string, object>("name", this.Name);
			yield return new KeyValuePair<string, object>("parentId", this.ParentId);
			yield return new KeyValuePair<string, object>("allocations", (IEnumerable<AccountCostCenterAllocation>)this.Allocations ?? Array.Empty<AccountCostCenterAllocation>());
			yield return new KeyValuePair<string, object>("purchaseAccountId", this.PurchaseAccountId);
			yield return new KeyValuePair<string, object>("salesAccountId", this.SalesAccountId);
			yield return new KeyValuePair<string, object>("sequenceNrId", this.sequenceNrId);
		}
	}
}
