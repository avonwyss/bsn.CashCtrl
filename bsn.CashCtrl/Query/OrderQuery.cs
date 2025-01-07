using System.Collections.Generic;
using System.ComponentModel;

using bsn.CashCtrl.Entities;

namespace bsn.CashCtrl.Query {
	public class OrderQuery: PagedQuery {
		[Description("The ID of the order category to filter by.")]
		public int? CategoryId {
			get;
			set;
		}
		[Description("The ID of the fiscal period, from which we retrieve the orders. Leave empty to use the current fiscal period.")]
		public int? FiscalperiodId {
			get;
			set;
		}

		[Description("The ID of the order group (dossier) to filter by.")]
		public int? GroupId {
			get;
			set;
		}

		[Description("The ID of the order status to filter by.")]
		public int? StatusId {
			get;
			set;
		}

		[Description("The type of order (sales or purchase). Possible values: SALES, PURCHASE.")]
		public OrderType? Type {
			get;
			set;
		}

		[Description("Flag to only include entries with cost centers. Defaults to false.")]
		public bool? OnlyCostCenters {
			get;
			set;
		}

		[Description("Flag to only include open orders (incomplete status like 'Open' as opposed to completed status like 'Paid'). Defaults to false.")]
		public bool? OnlyOpen {
			get;
			set;
		}

		[Description("Flag to only include orders that are overdue (past the due date). Defaults to false.")]
		public bool? OnlyOverdue {
			get;
			set;
		}

		public override IEnumerable<KeyValuePair<string, object>> ToParameters() {
			foreach (var parameter in base.ToParameters()) {
				yield return parameter;
			}
			yield return new("categoryId", this.CategoryId);
			yield return new("fiscalPeriodId", this.FiscalperiodId);
			yield return new("groupId", this.GroupId);
			yield return new("statusId", this.StatusId);
			yield return new("type", this.Type);
			yield return new("onlyCostCenters", this.OnlyCostCenters);
			yield return new("onlyOpen", this.OnlyOpen);
			yield return new("onlyOverdue", this.OnlyOverdue);
		}
	}
}
