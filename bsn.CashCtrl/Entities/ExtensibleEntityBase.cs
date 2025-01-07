using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace bsn.CashCtrl.Entities {
	public abstract class ExtensibleEntityBase: EntityBase, IApiSerializable {
		// ReSharper disable once FieldCanBeMadeReadOnly.Local - Must be read-write for cloning
		private VirtualList<Attachment> attachments = new VirtualList<Attachment>();

		public override bool Partial => base.Partial || this.attachments.HasVirtualValues;

		public virtual int AttachmentCount {
			get => this.attachments.Count;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => this.attachments.Count = value;
		}

		public virtual IReadOnlyList<Attachment> Attachments {
			get => this.attachments;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, false)]
			set => this.attachments.MakeSameAs(value);
		}

		public string Notes {
			get;
			set;
		}

		[JsonConverter(typeof(CustomFieldValuesConverter))]
		public IDictionary<string, string> Custom {
			get;
			set;
		}

		public virtual IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new("id", this.Id);
			}
			yield return new("custom", CustomFieldValuesConverter.ToXml(this.Custom));
			yield return new("notes", this.Notes);
		}
	}
}
