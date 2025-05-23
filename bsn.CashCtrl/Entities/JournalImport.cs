using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class JournalImport: FullEntityBase, IApiSerializable {
		public int? FileId {
			get;
			set;
		}

		public int? TargetAccountId {
			get;
			set;
		}

		public Attachment[] Attachments {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public ImportSource Source {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Description {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string SourceHash {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string CurrencyCode {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public AccountClass? TargetAccountClass {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			yield return new("fileId", this.FileId);
			yield return new("targetAccountId", this.TargetAccountId);
		}
	}
}
