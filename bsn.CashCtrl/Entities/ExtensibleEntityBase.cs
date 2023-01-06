using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace bsn.CashCtrl.Entities {
	public abstract class ExtensibleEntityBase: EntityBase, IApiSerializable {
		private int attachmentCount;

		public virtual int AttachmentCount {
			get => Attachments?.Length ?? attachmentCount;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, false)]
			set => attachmentCount = value;
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
			if (Id > 0) {
				yield return new KeyValuePair<string, object>("id", Id);
			}
			yield return new KeyValuePair<string, object>("custom", CustomFieldValuesConverter.ToXml(Custom));
			yield return new KeyValuePair<string, object>("notes", Notes);
			foreach (var pair in ToParametersInternal()) {
				yield return pair;
			}
		}

		protected abstract IEnumerable<KeyValuePair<string, object>> ToParametersInternal();
	}
}