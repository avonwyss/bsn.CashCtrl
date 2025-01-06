using System;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

using Newtonsoft.Json;

using OneOf;

namespace bsn.CashCtrl {
	[JsonConverter(typeof(LocalizedStringConverter))]
	public readonly struct LocalizedString: IFormattable, ICloneable {
		internal static readonly XName ValuesName = "values";

		public static implicit operator LocalizedString(string value) {
			return new(value);
		}

		public static explicit operator string(LocalizedString value) {
			return value.UnderlyingValue.Match(
					s => s,
					x => x.ToString(SaveOptions.DisableFormatting | SaveOptions.OmitDuplicateNamespaces));
		}

		public LocalizedString(OneOf<string, XElement> underlyingValue) {
			if (underlyingValue.TryPickT1(out var x, out _)) {
				if (x == null) {
					underlyingValue = new XElement(ValuesName);
				} else if (x.Name != ValuesName) {
					throw new ArgumentException("The XML contents must be a <values> element.");
				}
			}
			this.UnderlyingValue = underlyingValue;
		}

		public OneOf<string, XElement> UnderlyingValue {
			get;
		}

		public bool Empty => this.UnderlyingValue.Match(string.IsNullOrEmpty, x => !x.Elements().Any());

		public LocalizedString Set(string language, string value) {
			if (string.IsNullOrWhiteSpace(language)) {
				throw new ArgumentNullException(nameof(language));
			}
			var x = this.Empty
					? new(ValuesName)
					: this.UnderlyingValue.IsT1
							? this.UnderlyingValue.AsT1
							: throw new InvalidOperationException("Cannot set a value on an invariant LocalizedString");
			x.SetElementValue(language.ToLowerInvariant(), string.IsNullOrEmpty(value) ? null : value);
			return new(x);
		}

		public LocalizedString Multilanguage(string defaultLanguage = "DE") {
			if (string.IsNullOrWhiteSpace(defaultLanguage)) {
				throw new ArgumentNullException(nameof(defaultLanguage));
			}
			return this.IsMultilanguage
					? this
					: new(new XElement(ValuesName, new XElement(defaultLanguage.ToLowerInvariant(), this.UnderlyingValue.AsT0)));
		}

		public override bool Equals(object obj) {
			return string.Equals((string)(obj as LocalizedString?), (string)this, StringComparison.InvariantCulture);
		}

		public override int GetHashCode() {
			return StringComparer.InvariantCulture.GetHashCode((string)this);
		}

		public object Clone() {
			return new LocalizedString(this.UnderlyingValue
					.Match<OneOf<string, XElement>>(
							s => s,
							x => new XElement(x)));
		}

		string IFormattable.ToString(string format, IFormatProvider formatProvider) {
			return this.ToString((formatProvider as CultureInfo)?.TwoLetterISOLanguageName);
		}

		public override string ToString() {
			return this.ToString(null);
		}

		public string ToString(string language) {
			if (string.IsNullOrEmpty(language)) {
				language = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
			}
			return this.UnderlyingValue.Match(
					s => s,
					x => (x.Element(language.ToLowerInvariant()) ?? x.Elements().FirstOrDefault())?.Value);
		}

		public bool IsMultilanguage => this.UnderlyingValue.IsT1;

		public bool HasLanguage(string language) {
			return this.TryGetLanguage(language, out _);
		}

		public bool TryGetLanguage(string language, out string value) {
			if (string.IsNullOrEmpty(language)) {
				throw new ArgumentNullException(nameof(language));
			}
			if (this.UnderlyingValue.IsT1) {
				value = this.UnderlyingValue.AsT1.Element(language.ToLowerInvariant())?.Value;
				return !string.IsNullOrEmpty(value);
			}
			value = null;
			return false;
		}
	}
}
