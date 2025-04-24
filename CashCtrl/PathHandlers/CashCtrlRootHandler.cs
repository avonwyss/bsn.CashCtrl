using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

using bsn.CashCtrl;

namespace CashCtrl.PathHandlers {
	internal class CashCtrlRootHandler: CashCtrlPathHandler {
		private static readonly IReadOnlyDictionary<string, CashCtrlPathHandler> Handlers = CreateHandlerDictionary(
				new CashCtrlAccountsHandler(),
				new CashCtrlCurrenciesHandler(),
				new CashCtrlCustomFieldTypesHandler(),
				new CashCtrlRoundingsHandler(),
				new CashCtrlSequenceNumbersHandler(),
				new CashCtrlTaxesHandler(),
				new CashCtrlTextTypesHandler(),
				new CashCtrlFilesHandler(),
				new CashCtrlInventoryHandler(),
				new CashCtrlJournalsHandler(),
				new CashCtrlFiscalperiodsHandler(),
				new CashCtrlLocationsHandler(),
				new CashCtrlDomainHandler(),
				new CashCtrlSettingsHandler(),
				new CashCtrlOrdersHandler(),
				new CashCtrlPersonsHandler(),
				new CashCtrlReportHandler());

		public static IReadOnlyDictionary<string, CashCtrlPathHandler> CreateHandlerDictionary(params CashCtrlPathHandler[] nestedHandlers) {
			return nestedHandlers.ToDictionary(t => t.Name, StringComparer.OrdinalIgnoreCase);
		}

		public CashCtrlRootHandler(string driveRoot): base() {
			this.Name = driveRoot;
		}

		public override string Name {
			get;
		}

		public override bool IsContainer => true;

		public override bool Exists(CashCtrlClient client) {
			return true;
		}

		public override IEnumerable<CashCtrlPathHandler> GetChildHandlers(CashCtrlClient client, object parameters) {
			return Handlers.Values;
		}

		public override Func<string> GetChildItemCreator(CashCtrlClient client, object value, object parameters) {
			throw new NotSupportedException("The root object cannot be written to");
		}

		public override Action GetItemRemover(CashCtrlClient client, object parameters) {
			throw new NotSupportedException("The root object cannot be removed");
		}

		public override Action GetItemSetter(CashCtrlClient client, object value, object parameters) {
			throw new NotSupportedException("The root object cannot be written to");
		}

		public override object GetItemValue(CashCtrlClient client) {
			return new PSObject();
		}

		public override bool TryGetChildHandler(string name, out CashCtrlPathHandler handler) {
			return Handlers.TryGetValue(name, out handler);
		}

		public bool TryParsePath(string pathString, out CashCtrlPath path) {
			path = null;
			if (!string.IsNullOrEmpty(pathString)) {
				IReadOnlyList<string> segments = pathString.Split(PathSeparators, StringSplitOptions.RemoveEmptyEntries);

				void RemoveSegment(int index) {
					if (segments is not List<string> list) {
						list = segments.ToList();
						segments = list;
					}
					list.RemoveAt(index);
				}

				for (var i = segments.Count - 1; i >= 0; i--) {
					switch (segments[i]) {
					case ".":
						RemoveSegment(i);
						break;
					case "..":
						if (i <= 1) {
							return false;
						}
						RemoveSegment(i--);
						RemoveSegment(i);
						break;
					}
				}
				var handlers = new CashCtrlPathHandler[segments.Count];
				if (string.Equals(segments[0], this.Name, StringComparison.OrdinalIgnoreCase)) {
					handlers[0] = this;
					for (var i = 1; i < handlers.Length; i++) {
						if (!handlers[i - 1].TryGetChildHandler(segments[i], out handlers[i])) {
							return false;
						}
					}
					path = new(handlers);
					return true;
				}
			}
			return false;
		}
	}
}
