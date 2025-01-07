using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlCurrencyHandler: CashCtrlEntityHandler<Currency> {
		public CashCtrlCurrencyHandler(OneOf<int, Currency> idOrEntity): base(idOrEntity) { }

		protected override void CreateEntity(CashCtrlClient client, Currency entity) {
			client.CurrencyCreate(entity);
		}

		protected override Currency ReadEntity(CashCtrlClient client) {
			return client.CurrencyRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.CurrencyDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, Currency entity) {
			client.CurrencyUpdate(entity);
		}
	}
}
