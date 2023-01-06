using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using Newtonsoft.Json;

namespace bsn.CashCtrl {
	public class CustomFieldValuesConverter: JsonConverter {
		internal static readonly XName ValuesName = "values";

		internal static XElement ToXml(IDictionary<string, string> dict) {
			return dict == null
					? null
					: new XElement(ValuesName, dict.Select(p => new XElement(p.Key, p.Value)));
		}

		public override bool CanConvert(Type objectType) {
			return objectType == typeof(IDictionary<string, string>);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
			if (reader.TokenType == JsonToken.Null) {
				return null;
			}
			if (reader.TokenType == JsonToken.String) {
				var str = (string)reader.Value;
				if (string.IsNullOrEmpty(str)) {
					return null;
				}
				var xml = XElement.Parse(str, LoadOptions.None);
				if (xml.Name != ValuesName) {
					throw new JsonSerializationException("Unexpected custom field XML root element name.");
				}
				return xml.Elements().ToDictionary(e => e.Name.ToString(), e => e.Value, StringComparer.Ordinal);
			}
			throw new JsonSerializationException($"Unexpected token {reader.TokenType} when parsing localized string.");
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
			if (value == null) {
				writer.WriteNull();
			} else {
				var dict = (IDictionary<string, string>)value;
				serializer.Serialize(writer, ToXml(dict));
			}
		}
	}
}
