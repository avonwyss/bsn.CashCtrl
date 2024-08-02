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
			yield return new("accountId", this.AccountId);
			yield return new("currencyRate", this.CurrencyRate);
		}
	}
}
