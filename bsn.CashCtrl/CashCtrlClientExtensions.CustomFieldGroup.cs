using System.Collections.Generic;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static CustomFieldGroup CustomFieldGroupRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<CustomFieldGroup>>("customfield/group/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static CustomFieldGroup[] CustomFieldGroupList(this CashCtrlClient that, CustomFieldType type) {
			return that.Get<ListResponse<CustomFieldGroup>>("customfield/group/list.json", new KeyValuePair<string, object>[] {
					new(nameof(type), type)
			}).Data;
		}

		public static int CustomFieldGroupCreate(this CashCtrlClient that, CustomFieldGroup customField) {
			return that.Post<CreateResponse>("customfield/group/create.json", customField.ToParameters()).GetInsertIdOrThrow();
		}

		public static void CustomFieldGroupUpdate(this CashCtrlClient that, CustomFieldGroup customField) {
			that.Post<UpdateResponse>("customfield/group/update.json", customField.ToParameters()).EnsureSuccess();
		}

		public static void CustomFieldGroupDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("customfield/group/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static void CustomFieldGroupReorder(this CashCtrlClient that, int[] ids, int target, bool? before = default) {
			that.Post<ActionResponse>("customfield/group/reorder.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids),
					new(nameof(target), target),
					new(nameof(before), before)
			}).EnsureSuccess();
		}
	}
}
