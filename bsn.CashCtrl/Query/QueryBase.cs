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
		} = new();

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
			get => this.Filter?.Find(f => string.Equals(f.Field, field, StringComparison.OrdinalIgnoreCase))?.Value;
			set {
				this.Filter ??= new();
				var index = this.Filter.FindIndex(f => string.Equals(f.Field, field, StringComparison.OrdinalIgnoreCase));
				if (index >= 0) {
					if (value == null) {
						this.Filter.RemoveAt(index);
					} else {
						this.Filter[index] = new() { Field = field, Value = value };
					}
				} else if (value != null) {
					this.Filter.Add(new() { Field = field, Value = value });
				}
			}
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			yield return new("categoryId", this.CategoryId);
			yield return new("dir", this.Dir);
			if (this.Filter?.Count > 0) {
				yield return new("filter", this.Filter);
			}
			yield return new("start", this.Start);
			yield return new("limit", this.Limit);
			yield return new("query", this.Query);
			yield return new("sort", this.Sort);
			yield return new("onlyNotes", this.OnlyNotes);
			foreach (var pair in this.ToParametersInternal()) {
				yield return pair;
			}
		}

		protected abstract IEnumerable<KeyValuePair<string, object>> ToParametersInternal();
	}
}
