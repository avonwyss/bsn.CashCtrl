using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace bsn.CashCtrl.Query {
	[JsonConverter(typeof(StringEnumConverter), true)]
	public enum CashCtrlComparison {
		Eq,
		Like,
		Lt,
		Gt
	}
}
