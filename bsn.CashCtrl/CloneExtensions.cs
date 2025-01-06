using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace bsn.CashCtrl {
	public static class CloneExtensions {
		private static readonly ConcurrentDictionary<Type, FieldInfo[]> CloneableFields = new ConcurrentDictionary<Type, FieldInfo[]>();

		private static FieldInfo[] GetCloneableFields(Type type) {
			return CloneableFields.GetOrAdd(type, static t => t
					.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
					.Where(f => !f.IsInitOnly && typeof(ICloneable).IsAssignableFrom(f.FieldType))
					.ToArray());
		}

		/// <summary>
		/// Make a deep clone of an object, based on the following rules and assumptions:
		/// <list type="bullet">
		/// <item>The object implements <see cref="ICloneable.Clone()" /> as shallow copy of the object</item>
		/// <item>Each field of the object with a type implementing <see cref="ICloneable" /> is also replaced (deep cloned) recursively</item>
		/// </list>
		/// </summary>
		/// <param name="obj">The object to clone</param>
		/// <param name="clonedMap">A map of previously cloned objects, used to handle clones of object trees. The map should use a <see cref="ReferenceEqualityComparer{T}"/> for the key comparison.</param>
		/// <returns>The deeply cloned instance</returns>
		public static object DeepClone(ICloneable obj, IDictionary<ICloneable, object> clonedMap = null) { 
			if (obj == null) {
				return null;
			}
			object result;
			if (clonedMap == null) {
				clonedMap = new Dictionary<ICloneable, object>(ReferenceEqualityComparer<ICloneable>.Instance);
			} else if (clonedMap.TryGetValue(obj, out result)) {
				return result;
			}
			result = obj.Clone();
			Debug.Assert(result != null);
			clonedMap.Add(obj, result);
			if (ReferenceEquals(obj, result)) {
				// If a ICloneable.Clone() implementation returns itself, we assume the object is immutable
				return result;
			}
			var clonedQueue = new Queue<object>();
			clonedQueue.Enqueue(result);

			bool TryGetClone(object value, out object clone) {
				if (value is not ICloneable cloneable) {
					clone = value;
					return false;
				}
				if (clonedMap.TryGetValue(cloneable, out clone)) {
					return !ReferenceEquals(value, clone);
				}
				clone = cloneable.Clone();
				Debug.Assert(clone != null);
				if (ReferenceEquals(value, clone)) {
					return false;
				}
				clonedMap.Add(cloneable, clone);
				clonedQueue.Enqueue(clone);
				return true;
			}

			void ProcessArray(Array array, int[] indices, int dimension) {
				var lowerBound = array.GetLowerBound(dimension);
				var upperBound = array.GetUpperBound(dimension);
				for (var i = lowerBound; i <= upperBound; i++) {
					indices[dimension] = i;
					if (dimension < array.Rank - 1) {
						ProcessArray(array, indices, dimension + 1);
					} else if (TryGetClone(array.GetValue(indices), out var clone)) {
						array.SetValue(clone, indices);
					}
				}
			}

			do {
				var clone = clonedQueue.Dequeue();
				if (clone is Array array) {
					if (typeof(ICloneable).IsAssignableFrom(array.GetType().GetElementType())) {
						if (array.Rank == 1 && array.GetLowerBound(0) == 0) {
							for (var i = 0; i <= array.Length; i++) {
								if (TryGetClone(array.GetValue(i), out var clone1)) {
									array.SetValue(clone1, i);
								}
							}
						} else {
							// Not a SZArray, may need recursion
							ProcessArray(array, new int[array.Rank], 0);
						}
					}
				} else {
					foreach (var cloneableField in GetCloneableFields(clone.GetType())) {
						if (TryGetClone(cloneableField.GetValue(clone), out var valueClone)) {
							cloneableField.SetValue(clone, valueClone);
						}
					}
				}
			} while (clonedQueue.Count > 0);
			return result;
		}
	}
}
