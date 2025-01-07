using System;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace bsn.CashCtrl.Entities {
	public abstract class EntityBase: ICloneable {
		public static implicit operator int(EntityBase entity) {
			return entity.Id;
		}

		public static implicit operator int?(EntityBase entity) {
			return entity?.Id;
		}

		[JsonIgnore]
		public virtual bool Partial => false;

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

		public virtual bool OwnedByApi => this.CreatedBy.StartsWith("API:", StringComparison.Ordinal) || this.LastUpdatedBy.StartsWith("API:", StringComparison.Ordinal);

		public object Clone() {
			return this.MemberwiseClone();
		}
	}
}
