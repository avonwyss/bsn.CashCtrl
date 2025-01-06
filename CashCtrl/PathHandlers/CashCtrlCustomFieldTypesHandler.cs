using System;
using System.Linq;

using bsn.CashCtrl.Entities;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlCustomFieldTypesHandler: CashCtrlContainerHandler {
		public CashCtrlCustomFieldTypesHandler(): base("customfield",
				((CustomFieldType[])Enum.GetValues(typeof(CustomFieldType)))
				.Select(t => new CashCtrlCustomFieldsHandler(t))
				.ToArray<CashCtrlPathHandler>()) { }
	}
}
