using System;

namespace bsn.CashCtrl.Entities {
	public class InventoryAssetCategoryNode: InventoryAssetCategory {
		public int? PurchaseAccountId {
			[Obsolete(CashCtrlClient.EntityFieldAlwaysNull, true)]
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? SalesAccountId {
			[Obsolete(CashCtrlClient.EntityFieldAlwaysNull, true)]
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public InventoryAssetCategoryNode[] Data {
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
