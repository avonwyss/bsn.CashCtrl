using System.Collections.Generic;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int CustomFieldGroupCreate(this CashCtrlClient that, CustomFieldGroup customField) {
			return that.Post<CreateResponse>("customfield/group/create.json", customField.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> CustomFieldGroupCreateAsync(this CashCtrlClient that, CustomFieldGroup customField) {
			var response = await that.PostAsync<CreateResponse>("customfield/group/create.json", customField.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void CustomFieldGroupDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("customfield/group/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask CustomFieldGroupDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("customfield/group/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static CustomFieldGroup[] CustomFieldGroupList(this CashCtrlClient that, CustomFieldType type) {
			return that.Get<ListResponse<CustomFieldGroup>>("customfield/group/list.json", new KeyValuePair<string, object>[] {
					new(nameof(type), type)
			}).Data;
		}

		public static async ValueTask<CustomFieldGroup[]> CustomFieldGroupListAsync(this CashCtrlClient that, CustomFieldType type) {
			var response = await that.GetAsync<ListResponse<CustomFieldGroup>>("customfield/group/list.json", new KeyValuePair<string, object>[] {
					new(nameof(type), type)
			}).ConfigureAwait(false);
			return response.Data;
		}

		public static CustomFieldGroup CustomFieldGroupRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<CustomFieldGroup>>("customfield/group/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<CustomFieldGroup> CustomFieldGroupReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<CustomFieldGroup>>("customfield/group/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void CustomFieldGroupReorder(this CashCtrlClient that, int[] ids, int target, bool? before = default) {
			that.Post<ActionResponse>("customfield/group/reorder.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(target), target), new(nameof(before), before)
			}).EnsureSuccess();
		}

		public static async ValueTask CustomFieldGroupReorderAsync(this CashCtrlClient that, int[] ids, int target, bool? before = default) {
			var response = await that.PostAsync<ActionResponse>("customfield/group/reorder.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(target), target), new(nameof(before), before)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static void CustomFieldGroupUpdate(this CashCtrlClient that, CustomFieldGroup customField) {
			that.Post<UpdateResponse>("customfield/group/update.json", customField.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask CustomFieldGroupUpdateAsync(this CashCtrlClient that, CustomFieldGroup customField) {
			var response = await that.PostAsync<UpdateResponse>("customfield/group/update.json", customField.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
