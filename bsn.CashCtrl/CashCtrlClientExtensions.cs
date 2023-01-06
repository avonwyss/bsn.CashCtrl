using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using bsn.CashCtrl.Entities;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace bsn.CashCtrl {
	public static partial class CashCtrlClientExtensions {
		public const string CashCtrlDateTimeFormat = "yyyy'-'MM'-'dd HH':'mm':'ss'.'f";
		public const string CashCtrlDateFormat = "yyyy'-'MM'-'dd";

		private static readonly Dictionary<string, string> countryIsoMap = new(StringComparer.OrdinalIgnoreCase) {
				{ "AF", "AFG" },
				{ "AL", "ALB" },
				{ "DZ", "DZA" },
				{ "AS", "ASM" },
				{ "AD", "AND" },
				{ "AO", "AGO" },
				{ "AI", "AIA" },
				{ "AQ", "ATA" },
				{ "AG", "ATG" },
				{ "AR", "ARG" },
				{ "AM", "ARM" },
				{ "AW", "ABW" },
				{ "AU", "AUS" },
				{ "AT", "AUT" },
				{ "AZ", "AZE" },
				{ "BS", "BHS" },
				{ "BH", "BHR" },
				{ "BD", "BGD" },
				{ "BB", "BRB" },
				{ "BY", "BLR" },
				{ "BE", "BEL" },
				{ "BZ", "BLZ" },
				{ "BJ", "BEN" },
				{ "BM", "BMU" },
				{ "BT", "BTN" },
				{ "BO", "BOL" },
				{ "BQ", "BES" },
				{ "BA", "BIH" },
				{ "BW", "BWA" },
				{ "BV", "BVT" },
				{ "BR", "BRA" },
				{ "IO", "IOT" },
				{ "BN", "BRN" },
				{ "BG", "BGR" },
				{ "BF", "BFA" },
				{ "BI", "BDI" },
				{ "CV", "CPV" },
				{ "KH", "KHM" },
				{ "CM", "CMR" },
				{ "CA", "CAN" },
				{ "KY", "CYM" },
				{ "CF", "CAF" },
				{ "TD", "TCD" },
				{ "CL", "CHL" },
				{ "CN", "CHN" },
				{ "CX", "CXR" },
				{ "CC", "CCK" },
				{ "CO", "COL" },
				{ "KM", "COM" },
				{ "CD", "COD" },
				{ "CG", "COG" },
				{ "CK", "COK" },
				{ "CR", "CRI" },
				{ "HR", "HRV" },
				{ "CU", "CUB" },
				{ "CW", "CUW" },
				{ "CY", "CYP" },
				{ "CZ", "CZE" },
				{ "CI", "CIV" },
				{ "DK", "DNK" },
				{ "DJ", "DJI" },
				{ "DM", "DMA" },
				{ "DO", "DOM" },
				{ "EC", "ECU" },
				{ "EG", "EGY" },
				{ "SV", "SLV" },
				{ "GQ", "GNQ" },
				{ "ER", "ERI" },
				{ "EE", "EST" },
				{ "SZ", "SWZ" },
				{ "ET", "ETH" },
				{ "FK", "FLK" },
				{ "FO", "FRO" },
				{ "FJ", "FJI" },
				{ "FI", "FIN" },
				{ "FR", "FRA" },
				{ "GF", "GUF" },
				{ "PF", "PYF" },
				{ "TF", "ATF" },
				{ "GA", "GAB" },
				{ "GM", "GMB" },
				{ "GE", "GEO" },
				{ "DE", "DEU" },
				{ "GH", "GHA" },
				{ "GI", "GIB" },
				{ "GR", "GRC" },
				{ "GL", "GRL" },
				{ "GD", "GRD" },
				{ "GP", "GLP" },
				{ "GU", "GUM" },
				{ "GT", "GTM" },
				{ "GG", "GGY" },
				{ "GN", "GIN" },
				{ "GW", "GNB" },
				{ "GY", "GUY" },
				{ "HT", "HTI" },
				{ "HM", "HMD" },
				{ "VA", "VAT" },
				{ "HN", "HND" },
				{ "HK", "HKG" },
				{ "HU", "HUN" },
				{ "IS", "ISL" },
				{ "IN", "IND" },
				{ "ID", "IDN" },
				{ "IR", "IRN" },
				{ "IQ", "IRQ" },
				{ "IE", "IRL" },
				{ "IM", "IMN" },
				{ "IL", "ISR" },
				{ "IT", "ITA" },
				{ "JM", "JAM" },
				{ "JP", "JPN" },
				{ "JE", "JEY" },
				{ "JO", "JOR" },
				{ "KZ", "KAZ" },
				{ "KE", "KEN" },
				{ "KI", "KIR" },
				{ "KP", "PRK" },
				{ "KR", "KOR" },
				{ "KW", "KWT" },
				{ "KG", "KGZ" },
				{ "LA", "LAO" },
				{ "LV", "LVA" },
				{ "LB", "LBN" },
				{ "LS", "LSO" },
				{ "LR", "LBR" },
				{ "LY", "LBY" },
				{ "LI", "LIE" },
				{ "LT", "LTU" },
				{ "LU", "LUX" },
				{ "MO", "MAC" },
				{ "MG", "MDG" },
				{ "MW", "MWI" },
				{ "MY", "MYS" },
				{ "MV", "MDV" },
				{ "ML", "MLI" },
				{ "MT", "MLT" },
				{ "MH", "MHL" },
				{ "MQ", "MTQ" },
				{ "MR", "MRT" },
				{ "MU", "MUS" },
				{ "YT", "MYT" },
				{ "MX", "MEX" },
				{ "FM", "FSM" },
				{ "MD", "MDA" },
				{ "MC", "MCO" },
				{ "MN", "MNG" },
				{ "ME", "MNE" },
				{ "MS", "MSR" },
				{ "MA", "MAR" },
				{ "MZ", "MOZ" },
				{ "MM", "MMR" },
				{ "NA", "NAM" },
				{ "NR", "NRU" },
				{ "NP", "NPL" },
				{ "NL", "NLD" },
				{ "NC", "NCL" },
				{ "NZ", "NZL" },
				{ "NI", "NIC" },
				{ "NE", "NER" },
				{ "NG", "NGA" },
				{ "NU", "NIU" },
				{ "NF", "NFK" },
				{ "MK", "MKD" },
				{ "MP", "MNP" },
				{ "NO", "NOR" },
				{ "OM", "OMN" },
				{ "PK", "PAK" },
				{ "PW", "PLW" },
				{ "PS", "PSE" },
				{ "PA", "PAN" },
				{ "PG", "PNG" },
				{ "PY", "PRY" },
				{ "PE", "PER" },
				{ "PH", "PHL" },
				{ "PN", "PCN" },
				{ "PL", "POL" },
				{ "PT", "PRT" },
				{ "PR", "PRI" },
				{ "QA", "QAT" },
				{ "RO", "ROU" },
				{ "RU", "RUS" },
				{ "RW", "RWA" },
				{ "RE", "REU" },
				{ "BL", "BLM" },
				{ "SH", "SHN" },
				{ "KN", "KNA" },
				{ "LC", "LCA" },
				{ "MF", "MAF" },
				{ "PM", "SPM" },
				{ "VC", "VCT" },
				{ "WS", "WSM" },
				{ "SM", "SMR" },
				{ "ST", "STP" },
				{ "SA", "SAU" },
				{ "SN", "SEN" },
				{ "RS", "SRB" },
				{ "SC", "SYC" },
				{ "SL", "SLE" },
				{ "SG", "SGP" },
				{ "SX", "SXM" },
				{ "SK", "SVK" },
				{ "SI", "SVN" },
				{ "SB", "SLB" },
				{ "SO", "SOM" },
				{ "ZA", "ZAF" },
				{ "GS", "SGS" },
				{ "SS", "SSD" },
				{ "ES", "ESP" },
				{ "LK", "LKA" },
				{ "SD", "SDN" },
				{ "SR", "SUR" },
				{ "SJ", "SJM" },
				{ "SE", "SWE" },
				{ "CH", "CHE" },
				{ "SY", "SYR" },
				{ "TW", "TWN" },
				{ "TJ", "TJK" },
				{ "TZ", "TZA" },
				{ "TH", "THA" },
				{ "TL", "TLS" },
				{ "TG", "TGO" },
				{ "TK", "TKL" },
				{ "TO", "TON" },
				{ "TT", "TTO" },
				{ "TN", "TUN" },
				{ "TM", "TKM" },
				{ "TC", "TCA" },
				{ "TV", "TUV" },
				{ "TR", "TUR" },
				{ "UG", "UGA" },
				{ "UA", "UKR" },
				{ "AE", "ARE" },
				{ "GB", "GBR" },
				{ "UM", "UMI" },
				{ "US", "USA" },
				{ "UY", "URY" },
				{ "UZ", "UZB" },
				{ "VU", "VUT" },
				{ "VE", "VEN" },
				{ "VN", "VNM" },
				{ "VG", "VGB" },
				{ "VI", "VIR" },
				{ "WF", "WLF" },
				{ "EH", "ESH" },
				{ "YE", "YEM" },
				{ "ZM", "ZMB" },
				{ "ZW", "ZWE" },
				{ "AX", "ALA" }
		};

		public static string MapCountryToAlpha3(string alpha2) {
			return !string.IsNullOrEmpty(alpha2) && countryIsoMap.TryGetValue(alpha2, out var alpha3)
					? alpha3
					: alpha2;
		}

		public static string ToCashCtrlString(this DateTime that, bool omitTime = false) {
			return that.ToString(omitTime ? CashCtrlDateFormat : CashCtrlDateTimeFormat, CultureInfo.InvariantCulture);
		}

		public static string ToCashCtrlString(this DateTime? that, bool omitTime = false) {
			return that?.ToString(omitTime ? CashCtrlDateFormat : CashCtrlDateTimeFormat, CultureInfo.InvariantCulture);
		}

		public static DateTime ToCashCtrlDateTime(this string that) {
			return DateTime.SpecifyKind(DateTime.ParseExact(that, CashCtrlDateTimeFormat, CultureInfo.InvariantCulture), DateTimeKind.Local);
		}

		public static DateTime ToCashCtrlDate(this string that) {
			return DateTime.SpecifyKind(DateTime.ParseExact(that, CashCtrlDateFormat, CultureInfo.InvariantCulture), DateTimeKind.Local);
		}

		public static HttpContent Get(this CashCtrlClient that, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters) {
			return that.Invoke(HttpMethod.Get, endpoint, parameters);
		}

		public static string GetString(this CashCtrlClient that, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters) {
			using var reader=that.InvokeTextReader(HttpMethod.Get, endpoint, parameters);
			return reader.ReadToEnd();
		}

		public static int UpdateOrCreate<T>(this CashCtrlClient that, T entity, Action<CashCtrlClient, T> update, Func<CashCtrlClient, T, int> create) where T: EntityBase {
			if (entity.Id <= 0) {
				return create(that, entity);
			}
			update(that, entity);
			return entity.Id;
		}

		public static T UpdateOrCreate<T>(this CashCtrlClient that, T entity, Action<CashCtrlClient, T> update, Func<CashCtrlClient, T, int> create, Func<CashCtrlClient, int, T> read) where T: EntityBase {
			return read(that, UpdateOrCreate(that, entity, update, create));
		}

		public static async ValueTask<int> UpdateOrCreateAsync<T>(this CashCtrlClient that, T entity, Func<CashCtrlClient, T, ValueTask> update, Func<CashCtrlClient, T, ValueTask<int>> create) where T: EntityBase {
			if (entity.Id <= 0) {
				return await create(that, entity).ConfigureAwait(false);
			}
			await update(that, entity).ConfigureAwait(false);
			return entity.Id;
		}

		public static async ValueTask<T> UpdateOrCreateAsync<T>(this CashCtrlClient that, T entity, Func<CashCtrlClient, T, ValueTask> update, Func<CashCtrlClient, T, ValueTask<int>> create, Func<CashCtrlClient, int, ValueTask<T>> read) where T: EntityBase {
			var entityId = entity.Id;
			if (entityId <= 0) {
				entityId = await create(that, entity).ConfigureAwait(false);
			} else {
				await update(that, entity).ConfigureAwait(false);
			}
			return await read(that, entityId).ConfigureAwait(false);
		}

		public static ValueTask<HttpContent> GetAsync(this CashCtrlClient that, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters) {
			return that.InvokeAsync(HttpMethod.Get, endpoint, parameters);
		}

		public static T Get<T>(this CashCtrlClient that, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters) {
			return that.InvokeJson<T>(HttpMethod.Get, endpoint, parameters);
		}

		public static ValueTask<T> GetAsync<T>(this CashCtrlClient that, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters, CancellationToken cancellationToken = default) {
			return that.InvokeJsonAsync<T>(HttpMethod.Get, endpoint, parameters, cancellationToken);
		}

		public static T Delete<T>(this CashCtrlClient that, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters) {
			return that.InvokeJson<T>(HttpMethod.Delete, endpoint, parameters);
		}

		public static ValueTask<T> DeleteAsync<T>(this CashCtrlClient that, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters, CancellationToken cancellationToken = default) {
			return that.InvokeJsonAsync<T>(HttpMethod.Delete, endpoint, parameters, cancellationToken);
		}

		public static T Post<T>(this CashCtrlClient that, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters) {
			return that.InvokeJson<T>(HttpMethod.Post, endpoint, parameters);
		}

		public static ValueTask<T> PostAsync<T>(this CashCtrlClient that, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters, CancellationToken cancellationToken = default) {
			return that.InvokeJsonAsync<T>(HttpMethod.Post, endpoint, null, cancellationToken);
		}

		public static IEnumerable<KeyValuePair<string, object>> AsParameters(this JObject that) {
			return that.Properties()
					.Select(p => new KeyValuePair<string, object>(p.Name, p.Value));
		}

		public static int GetInsertId(this JObject that) {
			return AssertSuccessful(that)["insertId"].ToObject<int>();
		}

		public static JObject AssertSuccessful(this JObject that) {
			if (that.GetValue("success")?.ToObject<bool>() == false) {
				var errors = that.GetValue("errors") as JArray;
				var errorMessage = that.GetValue("errorMessage") as JValue;
				var message = that.GetValue("message") as JValue;
				throw new InvalidOperationException(
						$@"The API call was not successful: {(errors?.Count > 0 
								? string.Join(Environment.NewLine, errors?.Select(e => $"{e["field"].ToObject<string>()}: {e["message"].ToObject<string>()}")) 
								: errorMessage?.Value ?? message?.Value ?? that.ToString(Formatting.Indented))}");
			}
			return that;
		}
	}
}
