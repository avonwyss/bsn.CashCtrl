using System;
using System.Collections.Generic;

namespace bsn.CashCtrl {
	public interface IApiSerializable {
		public IEnumerable<KeyValuePair<string, object>> ToParameters();
	}
}
