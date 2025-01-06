using System;
using System.Linq;

using bsn.CashCtrl.Entities;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlTextTypesHandler: CashCtrlContainerHandler {
		public CashCtrlTextTypesHandler(): base("text",
				((TextType[])Enum.GetValues(typeof(TextType)))
				.Select(t => new CashCtrlTextsHandler(t))
				.ToArray<CashCtrlPathHandler>()) { }
	}
}
