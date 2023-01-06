using System.Collections.Generic;

using bsn.CashCtrl.Response;

using Newtonsoft.Json.Linq;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public static JObject SettingRead(this CashCtrlClient that) {
			return that.Get<JObject>("setting/read.json", null);
		}

		public static string SettingGet(this CashCtrlClient that, string name) {
			return that.GetString("setting/get", new KeyValuePair<string, object>[] {
					new(nameof(name), name)
			});
		}

		public static void SettingUpdate(this CashCtrlClient that, params KeyValuePair<string, object>[] settings) {
			that.Get<ActionResponse>("setting/update.json", settings).EnsureSuccess();
		}
	}
}
