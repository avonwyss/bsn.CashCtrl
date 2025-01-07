using System;
using System.Collections.Generic;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlTextsHandler: CashCtrlCollectionHandler<Text> {
		public CashCtrlTextsHandler(TextType type): base(UppercaseStringEnumConverter.EnumValueToString(type)) {
			this.Type = type;
		}

		public TextType Type {
			get;
		}

		protected override CashCtrlEntityHandler<Text> GetEntityHandler(OneOf<int, Text> idOrEntity) {
			return new CashCtrlTextHandler(idOrEntity);
		}

		protected override IEnumerable<Text> ListEntities(CashCtrlClient client, QueryBase query) {
			return client.TextList(this.Type);
		}
	}
}
