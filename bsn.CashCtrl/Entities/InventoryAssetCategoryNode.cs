using System;

namespace bsn.CashCtrl.Entities {
	public class InventoryAssetCategoryNode: InventoryArticleCategory {
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
