using System.Collections.Generic;

namespace bsn.CashCtrl {
	public class ReferenceEqualityComparer<T>: IEqualityComparer<T> where T : class {
		public static readonly ReferenceEqualityComparer<T> Instance = new ReferenceEqualityComparer<T>();
		public bool Equals(T x, T y) {
			return ReferenceEquals(x, y);
		}
		public int GetHashCode(T obj) {
			return System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(obj);
		}
	}
}
