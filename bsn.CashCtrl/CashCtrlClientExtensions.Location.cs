using System.Collections.Generic;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int LocationCreate(this CashCtrlClient that, Location location) {
			return that.Post<CreateResponse>("location/create.json", location.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> LocationCreateAsync(this CashCtrlClient that, Location location) {
			var response = await that.PostAsync<CreateResponse>("location/create.json", location.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void LocationDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("location/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask LocationDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("location/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static Location[] LocationList(this CashCtrlClient that) {
			return that.Get<ListResponse<Location>>("location/list.json", null).Data;
		}

		public static async ValueTask<Location[]> LocationListAsync(this CashCtrlClient that) {
			var response = await that.GetAsync<ListResponse<Location>>("location/list.json", null).ConfigureAwait(false);
			return response.Data;
		}

		public static Location LocationRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<Location>>("location/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<Location> LocationReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<Location>>("location/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void LocationUpdate(this CashCtrlClient that, Location location) {
			that.Post<UpdateResponse>("location/update.json", location.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask LocationUpdateAsync(this CashCtrlClient that, Location location) {
			var response = await that.PostAsync<UpdateResponse>("location/update.json", location.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
