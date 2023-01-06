using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class PersonCategory: EntityBase, IApiSerializable {
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
			if (Id > 0) {
				yield return new("id", Id);
			}
			yield return new("name", Name);
			yield return new("discountPercentage", DiscountPercentage);
			yield return new("parentId", ParentId);
			yield return new("sequenceNrId", SequenceNrId);
		}
	}
}