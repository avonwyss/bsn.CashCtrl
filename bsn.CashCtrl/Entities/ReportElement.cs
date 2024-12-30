using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace bsn.CashCtrl.Entities {
	public class ReportElement: EntityBase, IApiSerializable {
		public int? SetId {
			get;
			set;
		}

		public int? FileId {
			get;
			set;
		}

		public Attachment[] Attachments {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public ReportType Type {
			get;
			set;
		}

		public LocalizedString Name {
			get;
			set;
		}

		public string Text {
			get;
			set;
		}

		public int Pos {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		[JsonConverter(typeof(JsonStringConverter))]
		public JObject Config {
			get;
			set;
		} = new();

		public string State {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string StateName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsPageBreak {
			get;
			set;
		}

		public bool IsHideTitle {
			get;
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new("id", this.Id);
			}
			yield return new("type", this.Type);
			yield return new("config", this.Config);
			yield return new("fileId", this.FileId);
			yield return new("isHideTitle", this.IsHideTitle);
			yield return new("isPageBreak", this.IsPageBreak);
			yield return new("name", this.Name);
			yield return new("setId", this.SetId);
			yield return new("text", this.Text);
		}
	}
}
