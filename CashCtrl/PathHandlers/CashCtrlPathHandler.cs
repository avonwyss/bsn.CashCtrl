using System;
using System.Collections.Generic;

using bsn.CashCtrl;

namespace CashCtrl.PathHandlers {
	internal abstract class CashCtrlPathHandler {
		public const char PathSeparator = '\\';

		public static readonly char[] PathSeparators = {
				PathSeparator, '/'
		};

		public abstract string Name {
			get;
		}

		public abstract bool IsContainer {
			get;
		}

		public abstract bool Exists(CashCtrlClient client);

		public abstract IEnumerable<CashCtrlPathHandler> GetAllChildHandlers(CashCtrlClient client);

		public abstract object GetItemValue(CashCtrlClient client);

		public abstract Action GetItemSetter(CashCtrlClient client, object value);

		public abstract Action GetItemRemover(CashCtrlClient client);

		public abstract Action GetChildItemCreator(CashCtrlClient client, object value);

		public virtual bool TryGetChildHandler(string name, out CashCtrlPathHandler handler) {
			handler = null;
			return false;
		}

		public override string ToString() {
			return this.Name;
		}
	}
}
