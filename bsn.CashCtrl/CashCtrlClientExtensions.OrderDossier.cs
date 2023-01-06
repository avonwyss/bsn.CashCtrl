using System.Collections.Generic;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static OrderDossier OrderDossierRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<OrderDossier>>("order/dossier.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static void OrderDossierAdd(this CashCtrlClient that, int groupId, params int[] ids) {
			that.Post<ActionResponse>("order/dossier_add.json", new[] {
					new KeyValuePair<string, object>(nameof(groupId), groupId),
					new KeyValuePair<string, object>(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static void OrderDossierRemove(this CashCtrlClient that, int groupId, params int[] ids) {
			that.Post<ActionResponse>("order/dossier_add.json", new[] {
					new KeyValuePair<string, object>(nameof(groupId), groupId),
					new KeyValuePair<string, object>(nameof(ids), ids)
			}).EnsureSuccess();
		}
	}
}
