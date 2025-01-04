using System.Collections.Generic;
using System.Threading.Tasks;

using bsn.CashCtrl.Response;

using Newtonsoft.Json.Linq;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static string SettingGet(this CashCtrlClient that, string name) {
			return that.GetString("setting/get", new KeyValuePair<string, object>[] {
					new(nameof(name), name)
			});
		}

		public static async ValueTask<string> SettingGetAsync(this CashCtrlClient that, string name) {
			return await that.GetStringAsync("setting/get", new KeyValuePair<string, object>[] {
					new(nameof(name), name)
			}).ConfigureAwait(false);
		}

		public static JObject SettingRead(this CashCtrlClient that) {
			return that.Get<JObject>("setting/read.json", null);
		}

		public static async ValueTask<JObject> SettingReadAsync(this CashCtrlClient that) {
			return await that.GetAsync<JObject>("setting/read.json", null).ConfigureAwait(false);
		}

		public static void SettingUpdate(this CashCtrlClient that, params KeyValuePair<string, object>[] settings) {
			that.Get<ActionResponse>("setting/update.json", settings).EnsureSuccess();
		}

		public static async ValueTask SettingUpdateAsync(this CashCtrlClient that, params KeyValuePair<string, object>[] settings) {
			var response = await that.GetAsync<ActionResponse>("setting/update.json", settings).ConfigureAwait(false);
			response.EnsureSuccess();
		}
	}
}
