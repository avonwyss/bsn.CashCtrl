using System.Collections.Generic;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static Location LocationRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<Location>>("location/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static Location[] LocationList(this CashCtrlClient that) {
			return that.Get<ListResponse<Location>>("location/list.json", null).Data;
		}

		public static int LocationCreate(this CashCtrlClient that, Location location) {
			return that.Post<CreateResponse>("location/create.json", location.ToParameters()).GetInsertIdOrThrow();
		}

		public static void LocationUpdate(this CashCtrlClient that, Location location) {
			that.Post<UpdateResponse>("location/update.json", location.ToParameters()).EnsureSuccess();
		}

		public static void LocationDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("location/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}
	}
}
