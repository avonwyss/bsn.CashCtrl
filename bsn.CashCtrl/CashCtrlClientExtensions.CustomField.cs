using System.Collections.Generic;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static CustomField CustomFieldRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<CustomField>>("customfield/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static CustomField[] CustomFieldList(this CashCtrlClient that, CustomFieldType type) {
			return that.Get<ListResponse<CustomField>>("customfield/list.json", new KeyValuePair<string, object>[] {
					new(nameof(type), type)
			}).Data;
		}

		public static int CustomFieldCreate(this CashCtrlClient that, CustomField customField) {
			return that.Post<CreateResponse>("customfield/create.json", customField.ToParameters()).GetInsertIdOrThrow();
		}

		public static void CustomFieldUpdate(this CashCtrlClient that, CustomField customField) {
			that.Post<UpdateResponse>("customfield/update.json", customField.ToParameters()).EnsureSuccess();
		}

		public static void CustomFieldDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("customfield/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static void CustomFieldReorder(this CashCtrlClient that, int[] ids, int target, bool? before = default) {
			that.Post<ActionResponse>("customfield/reorder.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids),
					new(nameof(target), target),
					new(nameof(before), before)
			}).EnsureSuccess();
		}
	}
}
