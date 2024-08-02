using System;

namespace bsn.CashCtrl.Entities {
	public abstract class EntityBase {
		public static implicit operator int(EntityBase entity) => entity.Id;

		public static implicit operator int?(EntityBase entity) => entity?.Id;

		public int Id {
			get;
			set;
		}

		public DateTime Created {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string CreatedBy {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public DateTime LastUpdated {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string LastUpdatedBy {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public virtual bool OwnedByApi {
			get => this.CreatedBy.StartsWith("API:", StringComparison.Ordinal) || this.LastUpdatedBy.StartsWith("API:", StringComparison.Ordinal);
		}
	}
}
