using System;
using System.Collections.Generic;

using Microsoft.SqlServer.Server;

namespace bsn.CashCtrl.Entities {
	public class OrderItem: EntityBase, IApiSerializable {
		private static readonly char ApiMarker = '\u200C'; // Zero-Width Non-Joiner
		private string name;

		private static bool HasApiMarker(string value) {
			return !string.IsNullOrEmpty(value) && value[0] == ApiMarker;
		}

		private static string WithApiMarker(string value) {
			return HasApiMarker(value) ? value : value == null ? ApiMarker.ToString() : ApiMarker+value;
		}

		private static string WithoutApiMarker(string value) {
			return HasApiMarker(value) ? value.Substring(1) : value;
		}

		public int OrderId {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public int? InventoryId {
			get;
			set;
		}

		public int AccountId {
			get;
			set;
		}

		public int? TaxId {
			get;
			set;
		}

		public int? UnitId {
			get;
			set;
		}

		public string UnitName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public Attachment[] Attachments {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public AccountCostCenterAllocation[] Allocations {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public OrderItemType Type {
			get;
			set;
		} = OrderItemType.Article;

		public string ArticleNr {
			get;
			set;
		}

		public double Quantity {
			get;
			set;
		} = 1;

		public string Name {
			get => WithoutApiMarker(name);
			set => name = value;
		}

		public string Description {
			get;
			set;
		}

		public double UnitPrice {
			get;
			set;
		}

		public double? DiscountPercentage {
			get;
			set;
		}

		public int Pos {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public string TaxName {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double? DiscountEffective {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double? DiscountInherited {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double NetTotal {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double DefaultCurrencyNetTotal {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double DefaultCurrencyGrossTotal {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double DefaultCurrencyUnitPrice {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}
		
		public double NetUnitPrice {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}
		
		public double DefaultCurrencyNetUnitPrice {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double TaxRate {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}
		
		public TaxCalcType TaxCalcType {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double GrossTotal {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double TaxAmount {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public double TaxTotal {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}
		
		public bool IsInventoryArticle {
			get;
			[Obsolete(CashCtrlClient.EntityFieldIsReadonly, true)]
			set;
		}

		public override bool OwnedByApi => base.OwnedByApi || HasApiMarker(name);

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			yield return new("type", Type);
			yield return new("name", WithApiMarker(name));
			yield return new("description", Description);
			if (Type == OrderItemType.Article) {
				yield return new("accountId", AccountId);
				yield return new("unitPrice", UnitPrice);
				yield return new("articleNr", ArticleNr);
				yield return new("discountPercentage", DiscountPercentage);
				yield return new("inventoryId", InventoryId);
				yield return new("quantity", Quantity);
				yield return new("taxId", TaxId);
				yield return new("unitId", UnitId);
			}
		}
	}
}