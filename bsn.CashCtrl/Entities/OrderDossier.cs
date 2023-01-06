using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class OrderDossier: EntityItems<OrderDossierItem> {
		public class OrderTotals {
			public double InvoiceTotal {
				get;
				[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
				set;
			}

			public double InvoicePaid {
				get;
				[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
				set;
			}

			public double CreditNoteTotal {
				get;
				[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
				set;
			}

			public double CreditNotePaid {
				get;
				[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
				set;
			}

			public double Open {
				get;
				[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
				set;
			}
		}

		public Dictionary<OrderType, OrderTotals> TotalsMap {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}
	}
}