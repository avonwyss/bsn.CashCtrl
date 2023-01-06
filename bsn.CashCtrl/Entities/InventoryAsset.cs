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
			yield return new KeyValuePair<string, object>("name", Name);
			yield return new KeyValuePair<string, object>("accountId", AccountId);
			yield return new KeyValuePair<string, object>("dateAdded", DateAdded.ToCashCtrlString(true));
			yield return new KeyValuePair<string, object>("purchasePrice", PurchasePrice);
			yield return new KeyValuePair<string, object>("categoryId", CategoryId);
			yield return new KeyValuePair<string, object>("dateDisposed", DateDisposed?.ToCashCtrlString(true));
			yield return new KeyValuePair<string, object>("deprAccountId", DeprAccountId);
			yield return new KeyValuePair<string, object>("deprDuration", DeprDuration);
			yield return new KeyValuePair<string, object>("deprSalvageValue", DeprSalvageValue);
			yield return new KeyValuePair<string, object>("deprType", DeprType);
			yield return new KeyValuePair<string, object>("description", Description);
			yield return new KeyValuePair<string, object>("disposalDebitId", DisposalDebitId);
			yield return new KeyValuePair<string, object>("disposalType", DisposalType);
			if (PurchaseType == Entities.PurchaseType.Historical) {
				yield return new KeyValuePair<string, object>("initialValue", InitialValue);
			}
			yield return new KeyValuePair<string, object>("locationId", LocationId);
			if (!string.IsNullOrEmpty(Nr)) {
				yield return new KeyValuePair<string, object>("nr", Nr);
			}
			yield return new KeyValuePair<string, object>("saleAmount", SaleAmount);
			yield return new KeyValuePair<string, object>("saleCreditId", SaleCreditId);
			yield return new KeyValuePair<string, object>("saleDebitId", SaleDebitId);
			yield return new KeyValuePair<string, object>("saleTaxId", SaleTaxId);
			yield return new KeyValuePair<string, object>("sequenceNumberId", SequenceNumberId);
		}
	}
}
