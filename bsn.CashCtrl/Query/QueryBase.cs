using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Query {
	public abstract class QueryBase: IApiSerializable {
		public int? CategoryId {
			get;
			set;
		}

		public CashCtrlDirection? Dir {
			get;
			set;
		}

		public List<CashCtrlFilter> Filter {
			get;
			set;
		} = new ();

		public bool? OnlyNotes {
			get;
			set;
		}

		public int? Limit {
			get;
			set;
		}

		public int? Start {
			get;
			set;
		}

		public string Query {
			get;
			set;
		}

		public bool? Sort {
			get;
			set;
		}

		public object this[string field] {
			get => Filter?.Find(f => string.Equals(f.Field, field, StringComparison.OrdinalIgnoreCase))?.Value;
			set {
				Filter ??= new List<CashCtrlFilter>();
				var index = Filter.FindIndex(f => string.Equals(f.Field, field, StringComparison.OrdinalIgnoreCase));
				if (index >= 0) {
					if (value == null) {
						Filter.RemoveAt(index);
					} else {
						Filter[index] = new CashCtrlFilter() { Field = field, Value = value };
					}
				} else if (value != null) {
					Filter.Add(new CashCtrlFilter() { Field = field, Value = value });
				}
			}
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			yield return new("categoryId", CategoryId);
			yield return new("dir", Dir);
			if (Filter?.Count > 0) {
				yield return new("filter", Filter);
			}
			yield return new("start", Start);
			yield return new("limit", Limit);
			yield return new("query", Query);
			yield return new("sort", Sort);
			yield return new("onlyNotes", OnlyNotes);
			foreach (var pair in ToParametersInternal()) {
				yield return pair;
			}
		}

		protected abstract IEnumerable<KeyValuePair<string, object>> ToParametersInternal();
	}
}