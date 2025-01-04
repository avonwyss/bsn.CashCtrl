using System.Collections.Generic;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static void OrderDossierAdd(this CashCtrlClient that, int groupId, params int[] ids) {
			that.Post<ActionResponse>("order/dossier_add.json", new[] {
					new KeyValuePair<string, object>(nameof(groupId), groupId), new KeyValuePair<string, object>(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask OrderDossierAddAsync(this CashCtrlClient that, int groupId, params int[] ids) {
			var response = await that.PostAsync<ActionResponse>("order/dossier_add.json", new[] {
					new KeyValuePair<string, object>(nameof(groupId), groupId), new KeyValuePair<string, object>(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static OrderDossier OrderDossierRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<OrderDossier>>("order/dossier.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<OrderDossier> OrderDossierReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<OrderDossier>>("order/dossier.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void OrderDossierRemove(this CashCtrlClient that, int groupId, params int[] ids) {
			that.Post<ActionResponse>("order/dossier_add.json", new[] {
					new KeyValuePair<string, object>(nameof(groupId), groupId), new KeyValuePair<string, object>(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask OrderDossierRemoveAsync(this CashCtrlClient that, int groupId, params int[] ids) {
			var response = await that.PostAsync<ActionResponse>("order/dossier_add.json", new[] {
					new KeyValuePair<string, object>(nameof(groupId), groupId), new KeyValuePair<string, object>(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
