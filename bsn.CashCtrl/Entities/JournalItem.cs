using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class JournalItem: EntityBase, IApiSerializable, ICostCenterAllocatable {
		// ReSharper disable once FieldCanBeMadeReadOnly.Local - Must be read-write for cloning
		private VirtualList<AccountCostCenterAllocation> allocations = new();

		public int JournalId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int AccountId {
			get;
			set;
		}

		public int? TaxId {
			get;
			set;
		}

		public int? AssociateId {
			get;
			set;
		}

		public string Description {
			get;
			set;
		}

		public double? Debit {
			get;
			set;
		}

		public double? Credit {
			get;
			set;
		}

		public int Pos {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double? Amount {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public Account[] AffectedAccounts {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string TaxName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string AccountName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string AssociateName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			yield return new("accountId", this.AccountId);
			yield return new("associateId", this.AssociateId);
			yield return new("credit", this.Credit);
			yield return new("debit", this.Debit);
			yield return new("description", this.Description);
			yield return new("taxId", this.TaxId);
			yield return new("allocations", this.Allocations);
		}

		public int AllocationCount {
			get => this.allocations.Count;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => this.allocations.Count = value;
		}

		public IList<AccountCostCenterAllocation> Allocations {
			get => this.allocations;
			set => this.allocations.MakeSameAs(value);
		}
	}
}
