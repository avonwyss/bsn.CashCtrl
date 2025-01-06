using System;
using System.Collections.Generic;

using JetBrains.Annotations;

namespace bsn.CashCtrl {
	public sealed class CloneableList<T>: List<T>, ICloneable {
		public CloneableList() { }

		public CloneableList(int capacity): base(capacity) { }

		public CloneableList([NotNull] IEnumerable<T> collection): base(collection) { }

		public object Clone() {
			return new CloneableList<T>(this);
		}
	}
}
