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
			if (Id > 0) {
				yield return new("id", Id);
			}
			yield return new("name", Name);
			yield return new("pattern", Pattern);
			yield return new("currentDailyNumber", CurrentDailyNumber);
			yield return new("currentMonthlyNumber", CurrentMonthlyNumber);
			yield return new("currentYearlyNumber", CurrentYearlyNumber);
			yield return new("currentInfiniteNumber", CurrentInfiniteNumber);
			yield return new("dailyNumberDigits", DailyNumberDigits);
			yield return new("dayDigits", DayDigits);
			yield return new("monthlyNumberDigits", MonthlyNumberDigits);
			yield return new("monthDigits", MonthDigits);
			yield return new("yearNumberDigits", YearlyNumberDigits);
			yield return new("yearDigits", YearDigits);
			yield return new("infiniteNumberDigits", InfiniteNumberDigits);
		}
	}
}
