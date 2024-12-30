using System;
using System.Collections.Generic;

namespace bsn.CashCtrl.Entities {
	public class InventoryArticle: AllocationsEntityBase {
		public int? ThumbnailFileId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? CategoryId {
			get;
			set;
		}

		public LocalizedString CategoryDisplay {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? UnitId {
			get;
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

		public int? LocationId {
			get;
			set;
		}

		public LocalizedString LocationName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? CurrencyId {
			get;
			set;
		}

		public string CurrencyCode {
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

		public int? SequenceNumberId {
			get;
			set;
		}

		public InventoryType Type {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
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

		public double? SalesPrice {
			get;
			set;
		}

		public double? LastPurchasePrice {
			get;
			set;
		}

		public int? Stock {
			get;
			set;
		}

		public int? MinStock {
			get;
			set;
		}

		public int? MaxStock {
			get;
			set;
		}

		public string BinLocation {
			get;
			set;
		}

		public string CostCenterNumbers {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public bool IsStockArticle {
			get;
			set;
		}

		public bool IsInactive {
			get;
			set;
		}

		public bool IsSalesPriceGross {
			get;
			set;
		}

		public bool IsPurchasePriceGross {
			get;
			set;
		}

		protected override IEnumerable<KeyValuePair<string, object>> ToParametersInternal() {
			yield return new("name", this.Name);
			yield return new("binLocation", this.BinLocation);
			yield return new("categoryId", this.CategoryId);
			yield return new("currencyId", this.CurrencyId);
			yield return new("description", this.Description);
			yield return new("isInactive", this.IsInactive);
			yield return new("isPurchasePriceGross", this.IsPurchasePriceGross);
			yield return new("isSalesPriceGross", this.IsSalesPriceGross);
			yield return new("isStockArticle", this.IsStockArticle);
			yield return new("lastPurchasePrice", this.LastPurchasePrice);
			yield return new("locationId", this.LocationId);
			yield return new("maxStock", this.MaxStock);
			yield return new("minStock", this.MinStock);
			if (!string.IsNullOrEmpty(this.Nr)) {
				yield return new("nr", this.Nr);
			}
			yield return new("salesPrice", this.SalesPrice);
			yield return new("sequenceNumberId", this.SequenceNumberId);
			yield return new("stock", this.Stock);
			yield return new("unitId", this.UnitId);
		}
	}
}
