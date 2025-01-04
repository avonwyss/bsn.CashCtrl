using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static int TextCreate(this CashCtrlClient that, Text text) {
			return that.Post<CreateResponse>("text/create.json", text.ToParameters()).GetInsertIdOrThrow();
		}

		public static async ValueTask<int> TextCreateAsync(this CashCtrlClient that, Text text) {
			var response = await that.PostAsync<CreateResponse>("text/create.json", text.ToParameters()).ConfigureAwait(false);
			return response.GetInsertIdOrThrow();
		}

		public static void TextDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("text/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}

		public static async ValueTask TextDeleteAsync(this CashCtrlClient that, params int[] ids) {
			var response = await that.PostAsync<DeleteResponse>("text/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).ConfigureAwait(false);
			response.EnsureSuccess();
		}

		public static Text[] TextList(this CashCtrlClient that, TextType type) {
			return that.Get<ListResponse<Text>>("text/list.json", new KeyValuePair<string, object>[] {
					new(nameof(type), type)
			}).Data;
		}

		public static async ValueTask<Text[]> TextListAsync(this CashCtrlClient that, TextType type) {
			var response = await that.GetAsync<ListResponse<Text>>("text/list.json", new KeyValuePair<string, object>[] {
					new(nameof(type), type)
			}).ConfigureAwait(false);
			return response.Data;
		}

		public static Text TextRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<Text>>("text/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static async ValueTask<Text> TextReadAsync(this CashCtrlClient that, int id) {
			var response = await that.GetAsync<ReadResponse<Text>>("text/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).ConfigureAwait(false);
			return response.GetDataOrThrow();
		}

		public static void TextUpdate(this CashCtrlClient that, Text text) {
			that.Post<UpdateResponse>("text/update.json", text.ToParameters()).EnsureSuccess();
		}

		public static async ValueTask TextUpdateAsync(this CashCtrlClient that, Text text) {
			var response = await that.PostAsync<UpdateResponse>("text/update.json", text.ToParameters()).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
