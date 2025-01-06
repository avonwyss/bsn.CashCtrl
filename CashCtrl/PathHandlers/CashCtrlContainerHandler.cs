using System;
using System.Collections.Generic;
using System.Management.Automation;

using bsn.CashCtrl;

namespace CashCtrl.PathHandlers {
	internal abstract class CashCtrlContainerHandler: CashCtrlPathHandler {
		private readonly IReadOnlyDictionary<string, CashCtrlPathHandler> nestedHandlers;

		protected CashCtrlContainerHandler(string name, params CashCtrlPathHandler[] nestedHandlers) {
			this.Name = name;
			this.nestedHandlers = CashCtrlRootHandler.CreateHandlerDictionary(nestedHandlers);
		}

		public override string Name {
			get;
		}

		public override bool IsContainer => true;

		public override bool Exists(CashCtrlClient client) {
			return true;
		}

		public override IEnumerable<CashCtrlPathHandler> GetAllChildHandlers(CashCtrlClient client) {
			return this.nestedHandlers.Values;
		}

		public override object GetItemValue(CashCtrlClient client) {
			var result = new PSObject();
			result.Members.Add(new PSNoteProperty("Name", this.Name));
			return result;
		}

		public override Action GetItemSetter(CashCtrlClient client, object value) {
			throw new NotSupportedException("The object cannot be written to");
		}

		public override Action GetItemRemover(CashCtrlClient client) {
			throw new NotSupportedException("The object cannot be removed");
		}

		public override Action GetChildItemCreator(CashCtrlClient client, object value) {
			throw new NotSupportedException("The object cannot be written to");
		}

		public override bool TryGetChildHandler(string name, out CashCtrlPathHandler handler) {
			return this.nestedHandlers.TryGetValue(name, out handler);
		}
	}
}
