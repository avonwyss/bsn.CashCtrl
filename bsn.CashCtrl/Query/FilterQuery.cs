using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using bsn.CashCtrl.Entities;

namespace bsn.CashCtrl.Query {
	public class FilterQuery: QueryBase {
		// ReSharper disable once FieldCanBeMadeReadOnly.Local - Must be read-write for cloning
		private VirtualList<CashCtrlFilter> filters = new();

		[Description("An list of filters to filter the list. All filters must match (AND).")]
		public IList<CashCtrlFilter> Filters {
			get => this.filters;
			set => this.filters.MakeSameAs(value);
		}

		[Description("Flag to only include entries with notes. Defaults to false.")]
		public bool? OnlyNotes {
			get;
			set;
		}

		public object this[string field] {
			get => this.Filters.FirstOrDefault(f => string.Equals(f.Field, field, StringComparison.OrdinalIgnoreCase))?.Value;
			set {
				var index = this.Filters
						.Select((f, ix) => string.Equals(f.Field, field, StringComparison.OrdinalIgnoreCase) ? ix : default(int?))
						.FirstOrDefault(ix => ix.HasValue);
				if (index.HasValue) {
					if (value == null) {
						this.Filters.RemoveAt(index.Value);
					} else {
						this.Filters[index.Value] = new() { Field = field, Value = value };
					}
				} else if (value != null) {
					this.Filters.Add(new() { Field = field, Value = value });
				}
			}
		}

		public override IEnumerable<KeyValuePair<string, object>> ToParameters() {
			foreach (var parameter in base.ToParameters()) {
				yield return parameter;
			}
			yield return new("filter", this.Filters);
			yield return new("onlyNotes", this.OnlyNotes);
		}
	}
}
