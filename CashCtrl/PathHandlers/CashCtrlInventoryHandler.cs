namespace CashCtrl.PathHandlers {
	internal class CashCtrlInventoryHandler: CashCtrlContainerHandler {
		public CashCtrlInventoryHandler(): base("inventory",
				new CashCtrlInventoryArticlesHandler(),
				new CashCtrlInventoryAssetsHandler(),
				new CashCtrlInventoryUnitsHandler()) { }
	}
}
