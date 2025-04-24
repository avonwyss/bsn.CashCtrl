using bsn.CashCtrl;
using bsn.CashCtrl.Entities;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlReportElementHandler: CashCtrlEntityHandler<ReportElement> {
		public CashCtrlReportElementHandler(OneOf<int, ReportElement> idOrEntity): base(idOrEntity) { }

		protected override int CreateEntity(CashCtrlClient client, ReportElement entity) {
			return client.ReportElementCreate(entity);
		}

		protected override ReportElement ReadEntity(CashCtrlClient client) {
			return client.ReportElementRead(this.Id);
		}

		protected override void RemoveEntity(CashCtrlClient client) {
			client.ReportElementDelete(this.Id);
		}

		protected override void UpdateEntity(CashCtrlClient client, ReportElement entity) {
			client.ReportElementUpdate(entity);
		}
	}
}
