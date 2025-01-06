namespace CashCtrl.PathHandlers {
	internal class CashCtrlDomainHandler: CashCtrlContainerHandler {
		public CashCtrlDomainHandler(): base("domain",
				new CashCtrlDomainCurrentHandler()) { }
	}
}
