using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlTaxHandler: CashCtrlEntityHandler<Tax> {
		public CashCtrlTaxHandler(OneOf<int, Tax> idOrEntity): base(idOrEntity) { }

		protected override void CreateEntity(CashCtrlClient client, Tax entity) {
			client.TaxCreate(entity);
		}

		protected override Tax ReadEntity(CashCtrlClient client) {
			return client.TaxRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.TaxDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, Tax entity) {
			client.TaxUpdate(entity);
		}
	}
}
