using System;
using System.IO;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Response;

using Xunit;
using Xunit.Abstractions;

namespace bsn.CashCtrl {
	public sealed class CashCtrlClientTest: TestClassBase {
		public CashCtrlClientTest(ITestOutputHelper output): base(output) { }

		private void WriteAsJson<T>(T data) {
			using (var writer = new StringWriter()) {
				Client.JsonSerializer.Serialize(writer, data);
				Output.WriteLine(writer.ToString());
			}
		}
		
		[Fact]
		public void DateTimeFormat() {
			Assert.Equal("2022-07-18 00:00:00.0",  DateTime.SpecifyKind(new DateTime(2022, 07, 18), DateTimeKind.Utc).ToCashCtrlString());
		}

		[Fact]
		public void List() {
			var response = Client.AccountList();
			WriteAsJson(response);
		}

		[Fact]
		public async Task ListAsync() {
			var response = await Client.GetAsync<ListResponse<OrderCategory>>("order/category/list.json", null).ConfigureAwait(false);
			Output.WriteLine(response.Data[0].Status[0].Name.ToString("EN"));
			WriteAsJson(response);
		}
	}
}
