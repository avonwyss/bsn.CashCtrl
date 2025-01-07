using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class CustomFieldGroup: EntityBase, IApiSerializable {
		// ReSharper disable once FieldCanBeMadeReadOnly.Local - Must be read-write for cloning
		private VirtualList<CustomField> customFields = new();

		public IReadOnlyList<CustomField> CustomFields {
			get => this.customFields;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => this.customFields.MakeSameAs(value);
		}

		public LocalizedString Name {
			get;
			set;
		}

		public int Pos {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public CustomFieldType Type {
			get;
			set;
		}

		public string Value {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Text {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new("id", this.Id);
			}
			yield return new("name", this.Name);
			yield return new("type", this.Type);
		}
	}
}
