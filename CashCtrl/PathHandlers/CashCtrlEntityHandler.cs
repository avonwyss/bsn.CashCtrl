using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal abstract class CashCtrlEntityHandler<T>: CashCtrlPathHandler where T: EntityBase {
		public CashCtrlEntityHandler(OneOf<int, T> idOrEntity): base() {
			this.Id = idOrEntity.Match(
					id => id,
					entity => this.Entity = entity);
		}

		public T Entity {
			get;
			protected set;
		}

		public int Id {
			get;
		}

		public override string Name => this.Id.ToString(CultureInfo.InvariantCulture);

		public override bool IsContainer => false;

		protected virtual void CreateEntity(CashCtrlClient client, T entity) {
			throw new NotSupportedException();
		}

		public sealed override bool Exists(CashCtrlClient client) {
			try {
				return this.Entity != null || this.ReadEntity(client) != null;
			} catch (CashCtrlApiException) {
				return false;
			}
		}

		public override IEnumerable<CashCtrlPathHandler> GetChildHandlers(CashCtrlClient client, object parameters) {
			return Enumerable.Empty<CashCtrlPathHandler>();
		}

		public override Action GetChildItemCreator(CashCtrlClient client, object value, object parameters) {
			throw new NotSupportedException("The object cannot be written to");
		}

		public override Action GetItemRemover(CashCtrlClient client, object parameters) {
			return () => this.RemoveEntity(client);
		}

		public override Action GetItemSetter(CashCtrlClient client, object value, object parameters) {
			if (value is not PSObject psobj) {
				throw new ArgumentNullException(nameof(value));
			}
			if (!(psobj.BaseObject is T entity)) {
				throw new ArgumentException($"Expected a {typeof(T)}, but got a {value.GetType()}.", nameof(value));
			}
			if (entity.Id != this.Id) {
				entity = (T)entity.Clone();
				entity.Id = this.Id;
			}
			return () => {
				this.Entity = null;
				if (entity.Id > 0) {
					this.UpdateEntity(client, entity);
				} else {
					this.CreateEntity(client, entity);
				}
			};
		}

		public sealed override object GetItemValue(CashCtrlClient client) {
			if (this.Entity == null) {
				this.Entity = this.ReadEntity(client);
			}
			return new PSObject(this.Entity);
		}

		protected abstract T ReadEntity(CashCtrlClient client);

		protected virtual void RemoveEntity(CashCtrlClient client) {
			throw new NotSupportedException();
		}

		protected virtual void UpdateEntity(CashCtrlClient client, T entity) {
			throw new NotSupportedException();
		}
	}
}
