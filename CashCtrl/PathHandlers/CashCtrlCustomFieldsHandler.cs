using System;
using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlCustomFieldsHandler: CashCtrlCollectionHandler<CustomField> {
		public CashCtrlCustomFieldsHandler(CustomFieldType type): base(UppercaseStringEnumConverter.EnumValueToString(type),
				new CashCtrlCustomFieldGroupsHandler(type)) {
			this.Type = type;
		}

		public CustomFieldType Type {
			get;
		}

		protected override CashCtrlEntityHandler<CustomField> GetEntityHandler(OneOf<int, CustomField> idOrEntity) {
			return new CashCtrlCustomFieldHandler(idOrEntity);
		}

		protected override IEnumerable<CustomField> ListEntities(CashCtrlClient client, QueryBase query) {
			return client.CustomFieldList(this.Type);
		}
	}
}
