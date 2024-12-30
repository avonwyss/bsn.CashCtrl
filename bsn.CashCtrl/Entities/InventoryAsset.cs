using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class InventoryAsset: ExtensibleEntityBase {
		public int? CategoryId {
			get;
			set;
		}

		public int? ThumbnailFileId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? LocationId {
			get;
			set;
		}

		public LocalizedString LocationName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public LocalizedString CategoryDisplay {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? PurchaseCreditId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? PurchaseTaxId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? AccountId {
			get;
			set;
		}

		public string AccountDisplay {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? DeprAccountId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? DisposalDebitId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? SaleDebitId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? SaleCreditId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? SaleTaxId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public DateTime DateAdded {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string Nr {
			get;
			set;
		}

		public LocalizedString Name {
			get;
			set;
		}

		public LocalizedString Description {
			get;
			set;
		}

		public PurchaseType? PurchaseType {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public DisposalType? DisposalType {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double PurchasePrice {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double InitialValue {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public DepreciationType? DeprType {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double? DeprDuration {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double? DeprSalvageValue {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double CurrentValue {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public DateTime? DateDisposed {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double? SaleAmount {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? UnitId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public LocalizedString UnitName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? SalesAccountId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? PurchaseAccountId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? CurrencyId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string CurrencyCode {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? SequenceNumberId {
			get;
			set;
		}

		public InventoryType Type {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double? SalesPrice {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		protected override IEnumerable<KeyValuePair<string, object>> ToParametersInternal() {
			yield return new("name", this.Name);
			yield return new("accountId", this.AccountId);
			yield return new("dateAdded", this.DateAdded.ToCashCtrlString(true));
			yield return new("purchasePrice", this.PurchasePrice);
			yield return new("categoryId", this.CategoryId);
			yield return new("dateDisposed", this.DateDisposed?.ToCashCtrlString(true));
			yield return new("deprAccountId", this.DeprAccountId);
			yield return new("deprDuration", this.DeprDuration);
			yield return new("deprSalvageValue", this.DeprSalvageValue);
			yield return new("deprType", this.DeprType);
			yield return new("description", this.Description);
			yield return new("disposalDebitId", this.DisposalDebitId);
			yield return new("disposalType", this.DisposalType);
			if (this.PurchaseType == Entities.PurchaseType.Historical) {
				yield return new("initialValue", this.InitialValue);
			}
			yield return new("locationId", this.LocationId);
			if (!string.IsNullOrEmpty(this.Nr)) {
				yield return new("nr", this.Nr);
			}
			yield return new("saleAmount", this.SaleAmount);
			yield return new("saleCreditId", this.SaleCreditId);
			yield return new("saleDebitId", this.SaleDebitId);
			yield return new("saleTaxId", this.SaleTaxId);
			yield return new("sequenceNumberId", this.SequenceNumberId);
		}
	}
}
