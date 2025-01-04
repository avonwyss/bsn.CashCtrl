using System.Collections.Generic;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int OrderTemplateCreate(this CashCtrlClient that, OrderTemplate orderTemplate) {
			return that.Post<CreateResponse>("order/template/create.json", orderTemplate.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> OrderTemplateCreateAsync(this CashCtrlClient that, OrderTemplate orderTemplate) {
			var response = await that.PostAsync<CreateResponse>("order/template/create.json", orderTemplate.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void OrderTemplateDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("order/template/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask OrderTemplateDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("order/template/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static OrderTemplate[] OrderTemplateList(this CashCtrlClient that) {
			return that.Get<ListResponse<OrderTemplate>>("order/template/list.json", null).Data;
		}

		public static async ValueTask<OrderTemplate[]> OrderTemplateListAsync(this CashCtrlClient that) {
			var response = await that.GetAsync<ListResponse<OrderTemplate>>("order/template/list.json", null).ConfigureAwait(false);
			return response.Data;
		}

		public static OrderTemplate OrderTemplateRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<OrderTemplate>>("order/template/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<OrderTemplate> OrderTemplateReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<OrderTemplate>>("order/template/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void OrderTemplateUpdate(this CashCtrlClient that, OrderTemplate orderTemplate) {
			that.Post<UpdateResponse>("order/template/update.json", orderTemplate.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask OrderTemplateUpdateAsync(this CashCtrlClient that, OrderTemplate orderTemplate) {
			var response = await that.PostAsync<UpdateResponse>("order/template/update.json", orderTemplate.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
