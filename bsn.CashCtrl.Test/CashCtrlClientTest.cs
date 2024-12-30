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
				this.Client.JsonSerializer.Serialize(writer, data);
				this.Output.WriteLine(writer.ToString());
			}
		}
		
		[Fact]
		public void DateTimeFormat() {
			Assert.Equal("2022-07-18 00:00:00.0",  DateTime.SpecifyKind(new DateTime(2022, 07, 18), DateTimeKind.Utc).ToCashCtrlString());
		}

		[Fact]
		public void List() {
			var response = this.Client.AccountList();
			this.WriteAsJson(response);
		}

		[Fact]
		public async Task ListAsync() {
			var response = await this.Client.GetAsync<ListResponse<OrderCategory>>("order/category/list.json", null);
			this.Output.WriteLine(response.Data[0].Status[0].Name.ToString("EN"));
			this.WriteAsJson(response);
		}
	}
}
