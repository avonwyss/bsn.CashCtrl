using NLog;
using NLog.Config;
using NLog.Targets;

using Xunit.Abstractions;

namespace bsn.CashCtrl {
	internal class TestOutputTarget: TargetWithLayout {
		public static TestOutputTarget Configure(ITestOutputHelper output) {
			var target = new TestOutputTarget(output) { Layout = "${message}" };
			var config = new LoggingConfiguration();
			config.AddRuleForAllLevels(target);
			LogManager.Configuration = config;
			return target;
		}

		public ITestOutputHelper Output {
			get;
		}

		public TestOutputTarget(ITestOutputHelper output) {
			this.Output = output;
		}

		protected override void Write(LogEventInfo logEvent) {
			this.Output.WriteLine(this.RenderLogEvent(this.Layout, logEvent));
		}
	}
}
