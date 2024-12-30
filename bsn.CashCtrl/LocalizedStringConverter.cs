using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;

using Newtonsoft.Json;

namespace bsn.CashCtrl {
	public class LocalizedStringConverter: JsonConverter {
		private readonly Regex rxValues = new(@$"^\s*(\<{LocalizedString.ValuesName}\s*\>.*\</{LocalizedString.ValuesName}\s*\>|\<{LocalizedString.ValuesName}\s*\/\>)\s*$", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture);

		public override bool CanConvert(Type objectType) {
			return objectType == typeof(LocalizedString) || objectType == typeof(LocalizedString?);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
			var type = Nullable.GetUnderlyingType(objectType) ?? objectType;
			if (reader.TokenType == JsonToken.Null) {
				return type == objectType
						? new LocalizedString(default(string))
						: null;
			}
			if (reader.TokenType == JsonToken.String) {
				var str = (string)reader.Value;
				if (this.rxValues.IsMatch(str)) {
					try {
						return new LocalizedString(XElement.Parse(str, LoadOptions.None));
					} catch {
						// Looked like XML, but isn't XML, treat as string
					}
				}
				return new LocalizedString(str);
			}
			throw new JsonSerializationException($"Unexpected token {reader.TokenType} when parsing localized string.");
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
			if (value == null) {
				writer.WriteNull();
			} else {
				var localizedString = (LocalizedString)value;
				localizedString.UnderlyingValue.Switch(
						s => writer.WriteValue(s),
						x => writer.WriteValue(x.ToString(SaveOptions.DisableFormatting | SaveOptions.OmitDuplicateNamespaces)));
			}
		}
	}
}
