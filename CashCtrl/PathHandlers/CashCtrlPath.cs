using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlPath: IReadOnlyList<CashCtrlPathHandler> {
		private static readonly string PathSeparator = CashCtrlPathHandler.PathSeparator.ToString();

		private readonly IReadOnlyList<CashCtrlPathHandler> segments;

		public CashCtrlPath(IReadOnlyList<CashCtrlPathHandler> segments) {
			this.segments = segments;
		}

		public CashCtrlPathHandler Handler => this.segments[this.segments.Count - 1];

		public CashCtrlRootHandler Root => (CashCtrlRootHandler)this.segments[0];

		public IEnumerable<string> Names => this.segments.Select(static s => s.Name);

		public IEnumerator<CashCtrlPathHandler> GetEnumerator() {
			return this.segments.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return this.GetEnumerator();
		}

		public int Count => this.segments.Count;

		public CashCtrlPathHandler this[int index] => this.segments[index];

		public CashCtrlPath Append(CashCtrlPathHandler handler) {
			return new(this.segments.Append(handler).ToArray());
		}

		public CashCtrlPath Parent() {
			return new(this.segments.Take(this.Count - 1).ToArray());
		}

		public override string ToString() {
			return string.Join(PathSeparator, this.Names);
		}
	}
}
