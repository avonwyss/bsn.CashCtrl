using NLog;
using NLog.Targets;

using Xunit.Abstractions;

namespace bsn.CashCtrl {
	internal class TestOutputTarget: TargetWithLayout {
		private readonly ITestOutputHelper output;

		public TestOutputTarget(ITestOutputHelper output) {
			this.output = output;
		}

		protected override void Write(LogEventInfo logEvent) {
			output.WriteLine(RenderLogEvent(Layout, logEvent));
		}
	}
}
