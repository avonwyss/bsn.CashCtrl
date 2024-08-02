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
			yield return new("fiscalPeriodId", this.FiscalPeriodId);
			yield return new("groupId", this.GroupId);
			yield return new("statusId", this.StatusId);
			yield return new("type", this.Type);
			yield return new("onlyCostCenters", this.OnlyCostCenters);
			yield return new("onlyOpen", this.OnlyOpen);
			yield return new("onlyOverdue", this.OnlyOverdue);
		}
	}
}
