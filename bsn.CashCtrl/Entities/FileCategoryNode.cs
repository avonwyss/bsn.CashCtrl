using System;

namespace bsn.CashCtrl.Entities {
	public class FileCategoryNode: FileCategory {
		public FileCategoryNode[] Data {
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
