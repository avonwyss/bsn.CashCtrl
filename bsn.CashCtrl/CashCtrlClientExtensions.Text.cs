using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static Text TextRead(this CashCtrlClient that, int id) {
			return that.Get<ReadResponse<Text>>("text/read.json", new[] {
					new KeyValuePair<string, object>(nameof(id), id)
			}).GetDataOrThrow();
		}

		public static Text[] TextList(this CashCtrlClient that, TextType type) {
			return that.Get<ListResponse<Text>>("text/list.json", new KeyValuePair<string, object>[] {
					new(nameof(type), type)
			}).Data;
		}

		public static int TextCreate(this CashCtrlClient that, Text text) {
			return that.Post<CreateResponse>("text/create.json", text.ToParameters()).GetInsertIdOrThrow();
		}

		public static void TextUpdate(this CashCtrlClient that, Text text) {
			that.Post<UpdateResponse>("text/update.json", text.ToParameters()).EnsureSuccess();
		}

		public static void TextDelete(this CashCtrlClient that, params int[] ids) {
			that.Post<DeleteResponse>("text/delete.json", new KeyValuePair<string, object>[] {
					new(nameof(ids), ids)
			}).EnsureSuccess();
		}
	}
}
