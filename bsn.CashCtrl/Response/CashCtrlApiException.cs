using System;
using System.Linq;
using System.Runtime.Serialization;

namespace bsn.CashCtrl.Response {
	[Serializable]
	public class CashCtrlApiException: Exception {
		public CashCtrlApiException(string message): base(message) { }

		public CashCtrlApiException(string message, UpdateResponse.Error[] errors): base(
				errors?.Length > 0
						? string.IsNullOrEmpty(message) && errors.Length == 1 && string.IsNullOrEmpty(errors[0].Field)
								? errors[0].Message
								: $"{(string.IsNullOrEmpty(message) ? "The operation failed due to field errors." : message)} {string.Join("; ", errors.Select(e => $"{e.Field}: {e.Message}"))}"
						: string.IsNullOrEmpty(message)
								? "Unknown API error"
								: message) {
			this.Errors = errors ?? Array.Empty<UpdateResponse.Error>();
		}

		public CashCtrlApiException(string message, Exception innerException, string content): base(message, innerException) {
			this.ResponseContent = content;
		}

		protected CashCtrlApiException(SerializationInfo info, StreamingContext context): base(info, context) { }

		public string ResponseContent {
			get;
		}

		public UpdateResponse.Error[] Errors {
			get;
		} = Array.Empty<UpdateResponse.Error>();
	}
}
