using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;
using bsn.CashCtrl.Response;
using bsn.HttpClientSync;

namespace bsn.CashCtrl {
	internal struct CashCtrlAttachment {
		public static IEnumerable<CashCtrlAttachment> Create(IEnumerable<int> fileIds) {
			return fileIds.Select((id, ix) => new CashCtrlAttachment(id, ix));
		}

		public CashCtrlAttachment(int fileId, int pos) {
			this.FileId = fileId;
			this.Pos = pos;
		}

		public int FileId {
			get;
		}

		public int Pos {
			get;
		}
	}

	public static partial class CashCtrlClientExtensions {
		public static void OrderAttachmentsUpdate(this CashCtrlClient that, int id, params int[] fileIds) {
			that.Post<ActionResponse>("order/update_attachments.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new("attachments", CashCtrlAttachment.Create(fileIds))
			}).EnsureSuccess();
		}

		public static async ValueTask OrderAttachmentsUpdateAsync(this CashCtrlClient that, int id, params int[] fileIds) {
			var response = await that.PostAsync<ActionResponse>("order/update_attachments.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new("attachments", CashCtrlAttachment.Create(fileIds))
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static double OrderBalance(this CashCtrlClient that, int id, DateTime? date) {
			var data = that.GetString("order/balance", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new(nameof(date), date)
			});
			return double.Parse(data, CultureInfo.InvariantCulture);
		}

		public static async ValueTask<double> OrderBalanceAsync(this CashCtrlClient that, int id, DateTime? date) {
			var data = await that.GetStringAsync("order/balance", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new(nameof(date), date)
			}).ConfigureAwait(false);
			return double.Parse(data, CultureInfo.InvariantCulture);
		}

		public static void OrderContinueAs(this CashCtrlClient that, int[] ids, int categoryId, int? associateId = default, DateTime? date = default, string notes = default, int? statusId = default) {
			that.Post<UpdateResponse>("order/continue.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(categoryId), categoryId), new(nameof(associateId), associateId), new(nameof(date), date), new(nameof(notes), notes), new(nameof(statusId), statusId)
			}).EnsureSuccess();
		}

		public static async ValueTask OrderContinueAsAsync(this CashCtrlClient that, int[] ids, int categoryId, int? associateId = default, DateTime? date = default, string notes = default, int? statusId = default) {
			var response = await that.PostAsync<UpdateResponse>("order/continue.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids), new(nameof(categoryId), categoryId), new(nameof(associateId), associateId), new(nameof(date), date), new(nameof(notes), notes), new(nameof(statusId), statusId)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static int OrderCreate(this CashCtrlClient that, Order order) {
			return that.Post<CreateResponse>("order/create.json", order.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> OrderCreateAsync(this CashCtrlClient that, Order order) {
			var response = await that.PostAsync<CreateResponse>("order/create.json", order.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void OrderDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("order/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask OrderDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("order/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static Order[] OrderList(this CashCtrlClient that, OrderQuery query = default) {
			return that.Get<ListResponse<Order>>("order/list.json", query?.ToParameters()).Data;
		}

		public static Stream OrderList(this CashCtrlClient that, CashCtrlDownloadFormat format, OrderQuery query = default) {
			return that.Get($"order/list.{format.ToString().ToLowerInvariant()}", query?.ToParameters()).ReadAsStream();
		}

		public static async ValueTask<Order[]> OrderListAsync(this CashCtrlClient that, OrderQuery query = default) {
			var response = await that.GetAsync<ListResponse<Order>>("order/list.json", query?.ToParameters()).ConfigureAwait(false);
			return response.Data;
		}

		public static async ValueTask<Stream> OrderListAsync(this CashCtrlClient that, CashCtrlDownloadFormat format, OrderQuery query = default) {
			var content = await that.GetAsync($"order/list.{format.ToString().ToLowerInvariant()}", query?.ToParameters()).ConfigureAwait(false);
			return await content.ReadAsStreamAsync().ConfigureAwait(false);
		}

		public static Order OrderRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<Order>>("order/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<Order> OrderReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<Order>>("order/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void OrderRecurrenceUpdate(this CashCtrlClient that, int id, JournalRecurrence? recurrence = default, int? daysBefore = default, DateTime? startDate = default, DateTime? endDate = default, NotifyType? notifyType = default, string notifyEmail = default,
				int? notifyPersonId = default, int? notifyUserId = default) {
			that.Post<UpdateResponse>("order/update_recurrence.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id),
					new(nameof(recurrence), recurrence),
					new(nameof(daysBefore), daysBefore),
					new(nameof(startDate), startDate.ToCashCtrlString(true)),
					new(nameof(endDate), endDate.ToCashCtrlString(true)),
					new(nameof(notifyType), notifyType),
					new(nameof(notifyEmail), notifyEmail),
					new(nameof(notifyPersonId), notifyPersonId),
					new(nameof(notifyUserId), notifyUserId)
			}).EnsureSuccess();
		}

		public static async ValueTask OrderRecurrenceUpdateAsync(this CashCtrlClient that, int id, JournalRecurrence? recurrence = default, int? daysBefore = default, DateTime? startDate = default, DateTime? endDate = default, NotifyType? notifyType = default, string notifyEmail = default,
				int? notifyPersonId = default, int? notifyUserId = default) {
			var response = await that.PostAsync<UpdateResponse>("order/update_recurrence.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id),
					new(nameof(recurrence), recurrence),
					new(nameof(daysBefore), daysBefore),
					new(nameof(startDate), startDate.ToCashCtrlString(true)),
					new(nameof(endDate), endDate.ToCashCtrlString(true)),
					new(nameof(notifyType), notifyType),
					new(nameof(notifyEmail), notifyEmail),
					new(nameof(notifyPersonId), notifyPersonId),
					new(nameof(notifyUserId), notifyUserId)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static OrderStatus[] OrderStatusInfo(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<EntityItems<OrderStatus>>>("order/status_info.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).GetDataOrThrow().Items;
		}

		public static async ValueTask<OrderStatus[]> OrderStatusInfoAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<EntityItems<OrderStatus>>>("order/status_info.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow().Items;
		}

		public static void OrderStatusUpdate(this CashCtrlClient that, int id, int statusId) {
			that.Post<UpdateResponse>("order/update_status.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new(nameof(statusId), statusId)
			}).EnsureSuccess();
		}

		public static async ValueTask OrderStatusUpdateAsync(this CashCtrlClient that, int id, int statusId) {
			var response = await that.PostAsync<UpdateResponse>("order/update_status.json", new KeyValuePair<string, object>[] {
					new(nameof(id), id), new(nameof(statusId), statusId)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static void OrderUpdate(this CashCtrlClient that, Order order) {
			that.Post<UpdateResponse>("order/update.json", order.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask OrderUpdateAsync(this CashCtrlClient that, Order order) {
			var response = await that.PostAsync<UpdateResponse>("order/update.json", order.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
