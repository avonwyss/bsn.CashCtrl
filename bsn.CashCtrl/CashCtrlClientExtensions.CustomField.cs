using System.Collections.Generic;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int CustomFieldCreate(this CashCtrlClient that, CustomField customField) {
			return that.Post<CreateResponse>("customfield/create.json", customField.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> CustomFieldCreateAsync(this CashCtrlClient that, CustomField customField) {
			var response = await that.PostAsync<CreateResponse>("customfield/create.json", customField.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void CustomFieldDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("customfield/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask CustomFieldDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("customfield/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static CustomField[] CustomFieldList(this CashCtrlClient that, CustomFieldType type) {
			return that.Get<ListResponse<CustomField>>("customfield/list.json", new KeyValuePair<string, object>[] {
					new(nameof(type), type)
			}).Data;
		}

		public static async ValueTask<CustomField[]> CustomFieldListAsync(this CashCtrlClient that, CustomFieldType type) {
			var response = await that.GetAsync<ListResponse<CustomField>>("customfield/list.json", new KeyValuePair<string, object>[] {
					new(nameof(type), type)
			}).ConfigureAwait(false);
			return response.Data;
		}

		public static CustomField CustomFieldRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<CustomField>>("customfield/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<CustomField> CustomFieldReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<CustomField>>("customfield/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void CustomFieldReorder(this CashCtrlClient that, int[] ids, int target, bool? before = default) {
			that.Post<ActionResponse>("customfield/reorder.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(target), target), new(nameof(before), before)
			}).EnsureSuccess();
		}

		public static async ValueTask CustomFieldReorderAsync(this CashCtrlClient that, int[] ids, int target, bool? before = default) {
			var response = await that.PostAsync<ActionResponse>("customfield/reorder.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(target), target), new(nameof(before), before)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static void CustomFieldUpdate(this CashCtrlClient that, CustomField customField) {
			that.Post<UpdateResponse>("customfield/update.json", customField.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask CustomFieldUpdateAsync(this CashCtrlClient that, CustomField customField) {
			var response = await that.PostAsync<UpdateResponse>("customfield/update.json", customField.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
