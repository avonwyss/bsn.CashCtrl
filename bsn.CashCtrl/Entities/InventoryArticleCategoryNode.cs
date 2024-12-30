using System;

namespace bsn.CashCtrl.Entities {
	public class InventoryArticleCategoryNode: InventoryArticleCategory {
		public InventoryArticleCategoryNode[] Data {
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
