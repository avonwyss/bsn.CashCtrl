using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class InventoryArticleCategory: AllocationsEntityBase, IApiSerializable {
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

		protected override IEnumerable<KeyValuePair<string, object>> ToParametersInternal() {
			yield return new("name", this.Name);
			yield return new("parentId", this.ParentId);
			yield return new("purchaseAccountId", this.PurchaseAccountId);
			yield return new("salesAccountId", this.SalesAccountId);
			yield return new("sequenceNrId", this.sequenceNrId);
		}
	}
}
