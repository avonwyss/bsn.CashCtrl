using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class SequenceNumber: EntityBase, IApiSerializable {
		public LocalizedString Name {
			get;
			set;
		}

		public string Pattern {
			get;
			set;
		}

		public string CurrentValue {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int CurrentDailyNumber {
			get;
			set;
		}

		public int CurrentMonthlyNumber {
			get;
			set;
		}

		public int CurrentYearlyNumber {
			get;
			set;
		}

		public int CurrentInfiniteNumber {
			get;
			set;
		}

		public int DailyNumberDigits {
			get;
			set;
		}

		public int MonthlyNumberDigits {
			get;
			set;
		}

		public int YearlyNumberDigits {
			get;
			set;
		}

		public int InfiniteNumberDigits {
			get;
			set;
		}

		public int YearDigits {
			get;
			set;
		}

		public int MonthDigits {
			get;
			set;
		}

		public int DayDigits {
			get;
			set;
		}

		public DateTime LastIncrement {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
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

		public bool IsSkipExisting {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new("id", this.Id);
			}
			yield return new("name", this.Name);
			yield return new("pattern", this.Pattern);
			yield return new("currentDailyNumber", this.CurrentDailyNumber);
			yield return new("currentMonthlyNumber", this.CurrentMonthlyNumber);
			yield return new("currentYearlyNumber", this.CurrentYearlyNumber);
			yield return new("currentInfiniteNumber", this.CurrentInfiniteNumber);
			yield return new("dailyNumberDigits", this.DailyNumberDigits);
			yield return new("dayDigits", this.DayDigits);
			yield return new("monthlyNumberDigits", this.MonthlyNumberDigits);
			yield return new("monthDigits", this.MonthDigits);
			yield return new("yearNumberDigits", this.YearlyNumberDigits);
			yield return new("yearDigits", this.YearDigits);
			yield return new("infiniteNumberDigits", this.InfiniteNumberDigits);
		}
	}
}
