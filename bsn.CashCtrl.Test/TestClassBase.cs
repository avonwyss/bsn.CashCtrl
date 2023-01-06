using NLog;
using NLog.Config;

using Xunit.Abstractions;

namespace bsn.CashCtrl {
	public class TestClassBase {
		protected readonly CashCtrlClient client;
		protected readonly ITestOutputHelper output;

		public TestClassBase(ITestOutputHelper output) {
			this.output = output;
			var target = new TestOutputTarget(output) { Layout = "${message}" };
			var config = new LoggingConfiguration();
			config.AddRuleForAllLevels(target);
			LogManager.Configuration = config;
			client = new CashCtrlClient("mydomain", "mykey");
		}

		protected CashCtrlClient Client => client;

		protected ITestOutputHelper Output => output;
	}
}
