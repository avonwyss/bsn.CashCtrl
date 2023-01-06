using System.Collections.Generic;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static OrderTemplate OrderTemplateRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<OrderTemplate>>("order/template/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static OrderTemplate[] OrderTemplateList(this CashCtrlClient that) {
			return that.Get<ListResponse<OrderTemplate>>("order/template/list.json", null).Data;
		}

		public static int OrderTemplateCreate(this CashCtrlClient that, OrderTemplate orderTemplate) {
			return that.Post<CreateResponse>("order/template/create.json", orderTemplate.ToParameters()).GetInsertIdOrThrow();
		}

		public static void OrderTemplateUpdate(this CashCtrlClient that, OrderTemplate orderTemplate) {
			that.Post<UpdateResponse>("order/template/update.json", orderTemplate.ToParameters()).EnsureSuccess();
		}

		public static void OrderTemplateDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("order/template/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}
	}
}
