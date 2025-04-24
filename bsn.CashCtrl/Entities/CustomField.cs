using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace bsn.CashCtrl.Entities {
	public class CustomField: FullEntityBase, IApiSerializable {
		// ReSharper disable once FieldCanBeMadeReadOnly.Local - Must be read-write for cloning
		private VirtualList<string> values = new();

		public int? CategoryId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? GroupId {
			get;
			set;
		}

		public LocalizedString Name {
			get;
			set;
		}

		public LocalizedString Description {
			get;
			set;
		}

		public CustomFieldType Type {
			get;
			set;
		}

		public CustomFieldDataType DataType {
			get;
			set;
		}

		public JValue DefaultValue {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		[JsonConverter(typeof(JsonStringConverter))]
		public IList<string> Values {
			get => this.values;
			set => this.values.MakeSameAs(value);
		}

		public int Pos {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool Active {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string GroupName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string FieldId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsMulti {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsInactive {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new("id", this.Id);
			}
			yield return new("dataType", this.DataType);
			if (this.DataType == CustomFieldDataType.Combobox) {
				yield return new("values", this.Values);
			}
			yield return new("name", this.Name);
			yield return new("type", this.Type);
			yield return new("description", this.Description);
			if (this.GroupId.HasValue) {
				yield return new("groupId", this.GroupId);
			}
			yield return new("isInactive", this.IsInactive);
			yield return new("isMulti", this.IsMulti);
		}
	}
}
