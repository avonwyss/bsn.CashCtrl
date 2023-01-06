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
			if (Id > 0) {
				yield return new KeyValuePair<string, object>("id", Id);
			}
			yield return new KeyValuePair<string, object>("dataType", DataType);
			if (DataType == CustomFieldDataType.Combobox) {
				yield return new KeyValuePair<string, object>("values", Values);
			}
			yield return new KeyValuePair<string, object>("name", Name);
			yield return new KeyValuePair<string, object>("type", Type);
			yield return new KeyValuePair<string, object>("description", Description);
			if (GroupId.HasValue) {
				yield return new KeyValuePair<string, object>("groupId", GroupId);
			}
			yield return new KeyValuePair<string, object>("isInactive", IsInactive);
			yield return new KeyValuePair<string, object>("isMulti", IsMulti);
		}
	}
}
