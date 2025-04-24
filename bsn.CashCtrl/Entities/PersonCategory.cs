using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class PersonCategory: FullEntityBase, IApiSerializable {
		public int? ParentId {
			get;
			set;
		}

		public int? SequenceNrId {
			get;
			set;
		}

		public double? DiscountPercentage {
			get;
			set;
		}

		public double? DiscountInherited {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public LocalizedString Name {
			get;
			set;
		}

		public double? DiscountEffective {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double? SequenceNrIdInherited {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new("id", this.Id);
			}
			yield return new("name", this.Name);
			yield return new("discountPercentage", this.DiscountPercentage);
			yield return new("parentId", this.ParentId);
			yield return new("sequenceNrId", this.SequenceNrId);
		}
	}
}
