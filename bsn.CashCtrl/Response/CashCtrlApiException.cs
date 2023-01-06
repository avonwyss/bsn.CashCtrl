using System;
using System.Linq;
using System.Runtime.Serialization;

namespace bsn.CashCtrl.Response {
	[Serializable]
	public class CashCtrlApiException: Exception {
		public CashCtrlApiException(string message): base(message) { }

		public CashCtrlApiException(string message, UpdateResponse.Error[] errors): base(
				string.IsNullOrEmpty(message) && errors.Length == 1 && string.IsNullOrEmpty(errors[0].Field)
						? errors[0].Message
						: $"{(string.IsNullOrEmpty(message) ? "The operation failed due to field errors." : message)} {string.Join("; ", errors.Select(e => $"{e.Field}: {e.Message}"))}") {
			Errors = errors;
		}

		public CashCtrlApiException(string message, Exception innerException): base(message, innerException) { }

		protected CashCtrlApiException(SerializationInfo info, StreamingContext context): base(info, context) { }

		public UpdateResponse.Error[] Errors {
			get;
		} = Array.Empty<UpdateResponse.Error>();
	}
}
