using System;

using Newtonsoft.Json;

namespace bsn.CashCtrl.Entities {
	public abstract class FullEntityBase: EntityBase {
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

		public virtual bool OwnedByApi => this.CreatedBy?.StartsWith("API:", StringComparison.Ordinal) == true || this.LastUpdatedBy?.StartsWith("API:", StringComparison.Ordinal) == true;

		[JsonIgnore]
		public virtual bool Partial => false;
	}
}
