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
			yield return new KeyValuePair<string, object>("name", Name);
			yield return new KeyValuePair<string, object>("binLocation", BinLocation);
			yield return new KeyValuePair<string, object>("categoryId", CategoryId);
			yield return new KeyValuePair<string, object>("currencyId", CurrencyId);
			yield return new KeyValuePair<string, object>("description", Description);
			yield return new KeyValuePair<string, object>("isInactive", IsInactive);
			yield return new KeyValuePair<string, object>("isPurchasePriceGross", IsPurchasePriceGross);
			yield return new KeyValuePair<string, object>("isSalesPriceGross", IsSalesPriceGross);
			yield return new KeyValuePair<string, object>("isStockArticle", IsStockArticle);
			yield return new KeyValuePair<string, object>("lastPurchasePrice", LastPurchasePrice);
			yield return new KeyValuePair<string, object>("locationId", LocationId);
			yield return new KeyValuePair<string, object>("maxStock", MaxStock);
			yield return new KeyValuePair<string, object>("minStock", MinStock);
			if (!string.IsNullOrEmpty(Nr)) {
				yield return new KeyValuePair<string, object>("nr", Nr);
			}
			yield return new KeyValuePair<string, object>("salesPrice", SalesPrice);
			yield return new KeyValuePair<string, object>("sequenceNumberId", SequenceNumberId);
			yield return new KeyValuePair<string, object>("stock", Stock);
			yield return new KeyValuePair<string, object>("unitId", UnitId);
		}
	}
}
