using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class Fiscalperiod: EntityBase, IApiSerializable {
		private DateTime? end;
		private bool isCustom;
		private bool isEarliest;
		private DateTime? start;

		public string Name {
			get;
			set;
		}

		// ReSharper disable once ConvertToAutoPropertyWhenPossible
		public DateTime? Start {
			get => this.start;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => this.start = value;
		}

		// ReSharper disable once ConvertToAutoPropertyWhenPossible
		public DateTime? End {
			get => this.end;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set => this.end = value;
		}

		public string ShortName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public DateTime LastEntryDate {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string[] AvailableMonthIds {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string[] ClosedMonthIds {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool Month {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsClosed {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsCurrent {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsTransient {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			if (this.Id > 0) {
				yield return new KeyValuePair<string, object>("id", this.Id);
			}
			yield return new KeyValuePair<string, object>("name", this.Name);
			yield return new KeyValuePair<string, object>("isCustom", this.isCustom);
			if (this.isCustom) {
				// ReSharper disable once PossibleInvalidOperationException
				yield return new KeyValuePair<string, object>("end", this.End.Value.ToCashCtrlString(true));
				// ReSharper disable once PossibleInvalidOperationException
				yield return new KeyValuePair<string, object>("start", this.Start.Value.ToCashCtrlString(true));
			} else {
				yield return new KeyValuePair<string, object>("type", this.isEarliest ? "EARLIEST" : "LATEST");
			}
		}

		public void MakeCustom(DateTime start, DateTime end) {
			this.isCustom = true;
			this.start = start;
			this.end = end;
		}

		public void MakeEarliest() {
			this.isCustom = false;
			this.isEarliest = true;
		}

		public void MakeLatest() {
			this.isCustom = false;
			this.isEarliest = false;
		}
	}
}
