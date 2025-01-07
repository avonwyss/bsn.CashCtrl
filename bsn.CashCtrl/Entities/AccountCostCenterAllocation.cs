using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace bsn.CashCtrl.Entities {
	public class AccountCostCenterAllocation: IApiSerializable {
		public int Id {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? FromJournalId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? FromInventoryCategoryId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int ToCostCenterId {
			get;
			set;
		}

		public int Dimension {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double Share {
			get;
			set;
		}

		public int Pos {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Fullname {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			yield return new("share", this.Share);
			yield return new("toCostCenterId", this.ToCostCenterId);
		}
	}
}
