using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace bsn.CashCtrl.Entities {
	public class File: ExtensibleEntityBase {
		private int? replaceWith;

		public int? CategoryId {
			get;
			set;
		}

		public string CategoryName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Name {
			get;
			set;
		}

		public LocalizedString Description {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string MimeType {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public DateTime DateArchived {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int Size {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public void ReplaceWith(int preparedFileId) {
			this.replaceWith = preparedFileId;
		}

		protected override IEnumerable<KeyValuePair<string, object>> ToParametersInternal() {
			yield return new KeyValuePair<string, object>("name", this.Name);
			yield return new KeyValuePair<string, object>("categoryId", this.CategoryId);
			yield return new KeyValuePair<string, object>("description", this.Description);
			if (this.replaceWith.HasValue) {
				yield return new KeyValuePair<string, object>("replaceWith", this.replaceWith);
			}
		}

#pragma warning disable 612,618
		[JsonProperty("attachedTo")]
		public override Attachment[] Attachments {
			get => base.Attachments;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => base.Attachments = value;
		}

		[JsonProperty("attachedCount")]
		public override int AttachmentCount {
			get => base.AttachmentCount;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => base.AttachmentCount = value;
		}
#pragma warning restore 612,618
	}
}
