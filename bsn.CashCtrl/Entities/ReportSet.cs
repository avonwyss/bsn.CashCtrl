using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace bsn.CashCtrl.Entities {
	public class ReportSet: FullEntityBase, IApiSerializable {
		public struct ReportSetConfig {
			public bool? IsDisplayFooter {
				get;
				set;
			}

			public bool? IsDisplayHeader {
				get;
				set;
			}

			public bool? IsDisplayLogo {
				get;
				set;
			}

			public bool? IsDisplayPeriodInTitle {
				get;
				set;
			}

			public bool? IsDisplayTitle {
				get;
				set;
			}

			public int? LocationId {
				get;
				set;
			}

			public double? LogoHeight {
				get;
				set;
			}

			public PageSize? PageSize {
				get;
				set;
			}

			public int? ResponsiblePersonId {
				get;
				set;
			}
		}

		public ReportElement[] Elements {
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
		public ReportSetConfig Config {
			get;
			set;
		}

		public bool IsSystem {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsAnnualReport {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsDashboard {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new("id", this.Id);
			}
			yield return new("name", this.Name);
			yield return new("config", this.Config);
			yield return new("text", this.Text);
		}
	}
}
