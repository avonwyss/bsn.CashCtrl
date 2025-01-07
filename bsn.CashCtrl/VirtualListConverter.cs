using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

using Newtonsoft.Json;

namespace bsn.CashCtrl {
	public class VirtualListConverter: JsonConverter {
		private static readonly ConcurrentDictionary<Type, Func<JsonReader, object, JsonSerializer, object>> ReadJsonForType = new();
		private static readonly MethodInfo Meth_ReadJsonOfT = typeof(VirtualListConverter).GetMethod(nameof(ReadJson), BindingFlags.NonPublic | BindingFlags.Static);
		private static readonly ConcurrentDictionary<Type, Action<JsonWriter, object, JsonSerializer>> WriteJsonForType = new();
		private static readonly MethodInfo Meth_WriteJsonOfT = typeof(VirtualListConverter).GetMethod(nameof(WriteJson), BindingFlags.NonPublic | BindingFlags.Static);

		private static VirtualList<T> ReadJson<T>(JsonReader reader, VirtualList<T> existingValue, JsonSerializer serializer) {
			if (reader.TokenType == JsonToken.Null) {
				return existingValue;
			}
			if (existingValue == null) {
				existingValue = new();
			} else {
				existingValue.Clear();
			}
			if (reader.TokenType != JsonToken.StartArray) {
				throw new JsonSerializationException("Expected start of array.");
			}
			// Read until the end of the array
			while (reader.Read() && reader.TokenType != JsonToken.EndArray) {
				existingValue.Add(serializer.Deserialize<T>(reader));
			}
			if (reader.TokenType != JsonToken.EndArray) {
				throw new InvalidOperationException("Unexpected end of JSON data");
			}
			return existingValue;
		}

		private static void WriteJson<T>(JsonWriter writer, VirtualList<T> value, JsonSerializer serializer) {
			if (value.IsVirtual) {
				writer.WriteNull();
			} else {
				writer.WriteStartArray();
				foreach (var item in value) {
					serializer.Serialize(writer, item, typeof(T));
				}
				writer.WriteEndArray();
			}
		}

		public override bool CanConvert(Type objectType) {
			return objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(VirtualList<>);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
			if (existingValue != null) {
				objectType = existingValue.GetType();
			}
			Debug.Assert(this.CanConvert(objectType));
			Debug.Assert(existingValue == null || objectType.IsInstanceOfType(existingValue));
			var readJsonImpl = ReadJsonForType.GetOrAdd(objectType.GetGenericArguments()[0], static t => {
				var paraReader = Expression.Parameter(typeof(JsonReader), nameof(reader));
				var paraExistingValue = Expression.Parameter(typeof(object), nameof(existingValue));
				var paraSerializer = Expression.Parameter(typeof(JsonSerializer), nameof(serializer));
				return Expression.Lambda<Func<JsonReader, object, JsonSerializer, object>>(
								Expression.Convert(
										Expression.Call(Meth_ReadJsonOfT.MakeGenericMethod(t), paraReader, Expression.Convert(paraExistingValue, typeof(VirtualList<>).MakeGenericType(t)), paraSerializer),
										typeof(object)),
								paraReader, paraExistingValue, paraSerializer)
						.Compile();
			});
			return readJsonImpl(reader, existingValue, serializer);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
			if (value == null) {
				writer.WriteNull();
			} else {
				var objectType = value.GetType();
				Debug.Assert(this.CanConvert(objectType));
				var writeJsonImpl = WriteJsonForType.GetOrAdd(objectType.GetGenericArguments()[0], static t => {
					var paraWriter = Expression.Parameter(typeof(JsonWriter), nameof(writer));
					var paraValue = Expression.Parameter(typeof(object), nameof(value));
					var paraSerializer = Expression.Parameter(typeof(JsonSerializer), nameof(serializer));
					return Expression.Lambda<Action<JsonWriter, object, JsonSerializer>>(
									Expression.Call(Meth_WriteJsonOfT.MakeGenericMethod(t), paraWriter, Expression.Convert(paraValue, typeof(VirtualList<>).MakeGenericType(t)), paraSerializer),
									paraWriter, paraValue, paraSerializer)
							.Compile();
				});
				writeJsonImpl(writer, value, serializer);
			}
		}
	}
}
