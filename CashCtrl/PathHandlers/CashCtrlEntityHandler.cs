using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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

		protected virtual void RemoveEntity(CashCtrlClient client) {
			throw new NotSupportedException();
		}

		public sealed override bool Exists(CashCtrlClient client) {
			try {
				return this.Entity != null || this.ReadEntity(client) != null;
			} catch (CashCtrlApiException) {
				return false;
			}
		}

		public override IEnumerable<CashCtrlPathHandler> GetAllChildHandlers(CashCtrlClient client) {
			return Enumerable.Empty<CashCtrlPathHandler>();
		}

		public sealed override object GetItemValue(CashCtrlClient client) {
			if (this.Entity == null) {
				this.Entity = this.ReadEntity(client);
			}
			return this.Entity;
		}

		public override Action GetItemSetter(CashCtrlClient client, object value) {
			if (value == null) {
				throw new ArgumentNullException(nameof(value));
			}
			if (!(value is T entity)) {
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

		public override Action GetItemRemover(CashCtrlClient client) {
			return () => this.RemoveEntity(client);
		}

		public override Action GetChildItemCreator(CashCtrlClient client, object value) {
			throw new NotSupportedException("The object cannot be written to");
		}

		protected abstract T ReadEntity(CashCtrlClient client);

		protected virtual void UpdateEntity(CashCtrlClient client, T entity) {
			throw new NotSupportedException();
		}
	}
}
