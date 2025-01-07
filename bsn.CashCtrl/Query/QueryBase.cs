using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace bsn.CashCtrl.Query {
	public class QueryBase: IApiSerializable, ICloneable {
		[Description("The direction of the sort order (ascending or descending). Defaults to 'DESC'.")]
		public CashCtrlDirection? Dir {
			get;
			set;
		}

		[Description("Fulltext search query.")]
		public string Query {
			get;
			set;
		}

		[Description("The column to sort the list by.")]
		public string Sort {
			get;
			set;
		}

		public virtual IEnumerable<KeyValuePair<string, object>> ToParameters() {
			yield return new("dir", this.Dir);
			yield return new("query", this.Query);
			yield return new("sort", this.Sort);
		}

		public object Clone() {
			return this.MemberwiseClone();
		}
	}
}
