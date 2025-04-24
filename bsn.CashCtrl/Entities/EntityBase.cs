using System;

namespace bsn.CashCtrl.Entities {
	public abstract class EntityBase: ICloneable {
		public int Id {
			get;
			set;
		}

		public object Clone() {
			return this.MemberwiseClone();
		}

		public static implicit operator int(EntityBase entity) {
			return entity.Id;
		}

		public static implicit operator int?(EntityBase entity) {
			return entity?.Id;
		}
	}
}
