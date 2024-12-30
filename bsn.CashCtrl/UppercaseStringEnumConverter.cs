using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

using Newtonsoft.Json;

namespace bsn.CashCtrl {
	public class UppercaseStringEnumConverter: JsonConverter {
		private static readonly Regex rxCaseChange = new(@"(?<=\p{L})(?=\p{Lu})", RegexOptions.CultureInvariant | RegexOptions.Compiled | RegexOptions.ExplicitCapture);

		internal static string EnumValueToString(object value) {
			return rxCaseChange.Replace(value.ToString(), "_").ToUpperInvariant();
		}

		public override bool CanConvert(Type objectType) {
			return (Nullable.GetUnderlyingType(objectType) ?? objectType).IsEnum;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
			var type = Nullable.GetUnderlyingType(objectType) ?? objectType;
			if (reader.TokenType == JsonToken.Null) {
				return type == objectType
						? throw new JsonSerializationException($"Cannot convert null value to {objectType}.")
						: null;
			}
			try {
				if (reader.TokenType == JsonToken.String) {
					return Enum.Parse(type, reader.Value.ToString().Replace("_", ""), true);
				}
			} catch (Exception ex) {
				throw new JsonSerializationException($"Error converting value {reader.Value} to type '{objectType}'.", ex);
			}
			throw new JsonSerializationException($"Unexpected token {reader.TokenType} when parsing enum.");
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
			if (value == null) {
				writer.WriteNull();
			} else {
				Debug.Assert(value.GetType().IsEnum);
				writer.WriteValue(EnumValueToString(value));
			}
		}
	}
}
