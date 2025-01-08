using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace bsn.CashCtrl {
	public interface ICashCtrlClientCache {
		ValueTask<bool> TryGetCachedAsync(HttpMethod method, string endpoint, IReadOnlyCollection<KeyValuePair<string, string>> payloadStrings, StrongBox<TextReader> response, bool sync);

		ValueTask UpdateCacheAsync(HttpMethod method, string endpoint, IReadOnlyCollection<KeyValuePair<string, string>> payloadStrings, StrongBox<TextReader> response, bool sync);

		ValueTask ClearCacheAsync(bool sync);
	}
}
