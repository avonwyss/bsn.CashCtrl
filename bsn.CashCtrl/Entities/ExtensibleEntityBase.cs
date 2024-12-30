using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace bsn.CashCtrl.Entities {
	public abstract class ExtensibleEntityBase: EntityBase, IApiSerializable {
		private int attachmentCount;

		public virtual int AttachmentCount {
			get => this.Attachments?.Length ?? this.attachmentCount;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, false)]
			set => this.attachmentCount = value;
		}

		public virtual Attachment[] Attachments {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, false)]
			set;
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
			foreach (var pair in this.ToParametersInternal()) {
				yield return pair;
			}
		}

		protected abstract IEnumerable<KeyValuePair<string, object>> ToParametersInternal();
	}
}
