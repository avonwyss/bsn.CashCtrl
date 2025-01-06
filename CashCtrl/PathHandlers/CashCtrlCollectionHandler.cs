using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal abstract class CashCtrlCollectionHandler<T>: CashCtrlContainerHandler where T: EntityBase {
		public static bool TryParseId(string name, out int id) {
			return int.TryParse(name, NumberStyles.None, CultureInfo.InvariantCulture, out id) && id > 0;
		}

		protected CashCtrlCollectionHandler(string name, params CashCtrlPathHandler[] nestedHandlers): base(name, nestedHandlers) { }

		public override IEnumerable<CashCtrlPathHandler> GetAllChildHandlers(CashCtrlClient client) {
			foreach (var childHandler in base.GetAllChildHandlers(client)) {
				yield return childHandler;
			}
			foreach (var entity in this.ListEntities(client)) {
				yield return this.GetEntityHandler(entity);
			}
		}

		public override Action GetChildItemCreator(CashCtrlClient client, object value) {
			return this.GetEntityHandler(0).GetItemSetter(client, value);
		}

		protected abstract CashCtrlEntityHandler<T> GetEntityHandler(OneOf<int, T> idOrEntity);

		protected abstract IEnumerable<T> ListEntities(CashCtrlClient client);

		public override bool TryGetChildHandler(string name, out CashCtrlPathHandler handler) {
			if (base.TryGetChildHandler(name, out handler)) {
				return true;
			}
			if (TryParseId(name, out var id)) {
				handler = this.GetEntityHandler(id);
				return true;
			}
			return false;
		}
	}
}
