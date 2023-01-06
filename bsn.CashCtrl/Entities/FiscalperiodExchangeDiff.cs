using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class FiscalperiodExchangeDiff: IApiSerializable {
		public int AccountId {
			get;
			set;
		}

		public double CurrencyRate {
			get;
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			yield return new("accountId", AccountId);
			yield return new("currencyRate", CurrencyRate);
		}
	}
}
