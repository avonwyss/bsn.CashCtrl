using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace bsn.CashCtrl.Entities {
	public class CustomField: EntityBase, IApiSerializable {
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
		public List<string> Values {
			get;
			set;
		} = new List<string>(0);

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
				yield return new KeyValuePair<string, object>("id", this.Id);
			}
			yield return new KeyValuePair<string, object>("dataType", this.DataType);
			if (this.DataType == CustomFieldDataType.Combobox) {
				yield return new KeyValuePair<string, object>("values", this.Values);
			}
			yield return new KeyValuePair<string, object>("name", this.Name);
			yield return new KeyValuePair<string, object>("type", this.Type);
			yield return new KeyValuePair<string, object>("description", this.Description);
			if (this.GroupId.HasValue) {
				yield return new KeyValuePair<string, object>("groupId", this.GroupId);
			}
			yield return new KeyValuePair<string, object>("isInactive", this.IsInactive);
			yield return new KeyValuePair<string, object>("isMulti", this.IsMulti);
		}
	}
}
