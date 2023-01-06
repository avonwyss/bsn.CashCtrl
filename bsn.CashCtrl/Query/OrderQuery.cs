using System.Collections.Generic;

using bsn.CashCtrl.Entities;

namespace bsn.CashCtrl.Query {
	public class OrderQuery: QueryBase {
		public int? FiscalPeriodId {
			get;
			set;
		}

		public int? GroupId {
			get;
			set;
		}

		public int? StatusId {
			get;
			set;
		}

		public OrderType? Type {
			get;
			set;
		}

		public bool? OnlyCostCenters {
			get;
			set;
		}

		public bool? OnlyOpen {
			get;
			set;
		}

		public bool? OnlyOverdue {
			get;
			set;
		}

		protected override IEnumerable<KeyValuePair<string, object>> ToParametersInternal() {
			yield return new("fiscalPeriodId", FiscalPeriodId);
			yield return new("groupId", GroupId);
			yield return new("statusId", StatusId);
			yield return new("type", Type);
			yield return new("onlyCostCenters", OnlyCostCenters);
			yield return new("onlyOpen", OnlyOpen);
			yield return new("onlyOverdue", OnlyOverdue);
		}
	}
}
