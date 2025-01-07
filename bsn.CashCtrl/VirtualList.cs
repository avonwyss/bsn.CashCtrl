using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using OneOf;

namespace bsn.CashCtrl {
	[JsonConverter(typeof(VirtualListConverter))]
	internal sealed class VirtualList<T>: IList<T>, IReadOnlyList<T>, ICloneable, IVirtual {
		private OneOf<int, List<T>> items;

		public bool HasVirtualValues => this.items.Match(static count => count > 0, static _ => false);

		public object Clone() {
			var result = (VirtualList<T>)this.MemberwiseClone();
			result.items = this.items.Match<OneOf<int, List<T>>>(count => count, list => list == null ? null : new List<T>(list));
			return result;
		}

		public IEnumerator<T> GetEnumerator() {
			return (this.Count == 0 ? Enumerable.Empty<T>() : this.GetList()).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return this.GetEnumerator();
		}

		public void Add(T item) {
			this.GetList().Add(item);
		}

		public void Clear() {
			if (this.Count > 0) {
				this.GetList().Clear();
			}
		}

		public bool Contains(T item) {
			return this.Count > 0 && this.GetList().Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex) {
			if (this.Count > 0) {
				this.GetList().CopyTo(array, arrayIndex);
			}
		}

		public bool Remove(T item) {
			return this.Count > 0 && this.GetList().Remove(item);
		}

		public int Count {
			get => this.items.Match(static count => count, static list => list?.Count ?? 0);
			set => this.items.Switch(_ => this.items = value, list => this.items = list?.Count == value ? list : value);
		}

		public bool IsReadOnly => false;

		public int IndexOf(T item) {
			if (this.Count == 0) {
				return -1;
			}
			return this.GetList().IndexOf(item);
		}

		public void Insert(int index, T item) {
			this.GetList().Insert(index, item);
		}

		public void RemoveAt(int index) {
			this.GetList().RemoveAt(index);
		}

		public T this[int index] {
			get => this.GetList()[index];
			set => this.GetList()[index] = value;
		}

		public bool IsVirtual => this.items.Match(static count => true, static list => list == null);

		private List<T> GetList() {
			return this.items.Match(
					count => {
						var list = new List<T>(count);
						this.items = list;
						if (count > 0) {
							throw new InvalidOperationException($"The list {this.GetType().Name} has been prepared for {count} items, but has not and cannot be loaded.");
						}
						return list;
					},
					list => {
						if (list == null) {
							list = new();
							this.items = list;
						}
						return list;
					});
		}

		public void MakeSameAs(IEnumerable<T> value) {
			if (ReferenceEquals(value, this)) {
				return;
			}
			if (value == null) {
				this.items = 0;
				return;
			}
			if (value is VirtualList<T> { IsVirtual: true } virtualList) {
				this.items = virtualList.items;
				return;
			}
			if (this.IsVirtual) {
				this.items = new List<T>();
			} else {
				this.Clear();
			}
			this.GetList().AddRange(value);
		}

		internal void MakeVirtual(int count) {
			this.items = count;
		}
	}
}
