using System;
using System.IO;

using Newtonsoft.Json;

namespace bsn.CashCtrl {
	public class JsonStringConverter: JsonConverter {
		public override bool CanConvert(Type objectType) {
			return true;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
			if (reader.TokenType == JsonToken.Null) {
				return null;
			}
			if (reader.TokenType == JsonToken.String) {
				using (var textReader = new StringReader((string)reader.Value)) {
					return serializer.Deserialize(textReader, objectType);
				}
			}
			throw new JsonSerializationException($"Unexpected token {reader.TokenType} when parsing JSON string.");
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
			if (value == null) {
				writer.WriteNull();
			} else {
				using (var textWriter = new StringWriter()) {
					serializer.Serialize(textWriter, value);
					writer.WriteValue(textWriter.ToString());
				}
			}
		}
	}
}
