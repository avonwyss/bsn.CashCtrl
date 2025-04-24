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

		public abstract IEnumerable<CashCtrlPathHandler> GetChildHandlers(CashCtrlClient client, object parameters);

		public virtual object GetChildHandlersDynamicParameters() {
			return null;
		}

		public abstract Func<string> GetChildItemCreator(CashCtrlClient client, object value, object parameters);

		public virtual object GetItemCreateDynamicParameters() {
			return null;
		}

		public virtual object GetItemRemoveDynamicParameters() {
			return null;
		}

		public abstract Action GetItemRemover(CashCtrlClient client, object parameters);

		public virtual object GetItemSetDynamicParameters() {
			return null;
		}

		public abstract Action GetItemSetter(CashCtrlClient client, object value, object parameters);

		public abstract object GetItemValue(CashCtrlClient client);

		public override string ToString() {
			return this.Name;
		}

		public virtual bool TryGetChildHandler(string name, out CashCtrlPathHandler handler) {
			handler = null;
			return false;
		}
	}
}
