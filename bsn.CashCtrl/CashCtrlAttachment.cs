using System.Collections.Generic;
using System.Linq;

namespace bsn.CashCtrl {
	internal struct CashCtrlAttachment: IApiSerializable {
		public static CashCtrlAttachment[] Create(IEnumerable<int> fileIds) {
			return fileIds
					.Select((id, ix) => new CashCtrlAttachment(id, ix))
					.ToArray();
		}

		public CashCtrlAttachment(int fileId, int pos) {
			this.FileId = fileId;
			this.Pos = pos;
		}

		public int FileId {
			get;
		}

		public int Pos {
			get;
		}

		public IEnumerable<KeyValuePair<string, object>> ToParameters() {
			yield return new("fileId", this.FileId);
			yield return new("pos", this.Pos);
		}
	}
}
