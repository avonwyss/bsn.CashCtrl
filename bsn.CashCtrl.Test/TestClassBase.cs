using Xunit.Abstractions;

namespace bsn.CashCtrl {
	public abstract class TestClassBase {
		protected TestClassBase(ITestOutputHelper output) {
			this.Output = output;
			TestOutputTarget.Configure(output);
			this.Client = new CashCtrlClient("mydomain", "mykey");
		}

		protected ITestOutputHelper Output {
			get;
		}

		protected CashCtrlClient Client {
			get;
		}
	}
}
