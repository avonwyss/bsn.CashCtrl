using System;
using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlCustomFieldGroupsHandler: CashCtrlCollectionHandler<CustomFieldGroup> {
		public CashCtrlCustomFieldGroupsHandler(CustomFieldType type): base("group") {
			this.Type = type;
		}

		public CustomFieldType Type {
			get;
		}

		protected override CashCtrlEntityHandler<CustomFieldGroup> GetEntityHandler(OneOf<int, CustomFieldGroup> idOrEntity) {
			return new CashCtrlCustomFieldGroupHandler(idOrEntity);
		}

		protected override IEnumerable<CustomFieldGroup> ListEntities(CashCtrlClient client, QueryBase query) {
			return client.CustomFieldGroupList(this.Type);
		}
	}
}
