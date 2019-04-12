using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace BookStore.Localization.Dictionaries
{
	public class LocalizationDictionary : ILocalizationDictionary, IEnumerable<LocalizedString>
	{
		public CultureInfo CultureInfo { get; private set; }

		/// <inheritdoc/>
		public virtual string this[string name]
		{
			get
			{
				var localizedString = GetOrNull(name);
				return localizedString?.Value;
			}
			set
			{
				dictionary[name] = new LocalizedString(name, value, CultureInfo);
			}
		}

		private readonly Dictionary<string, LocalizedString> dictionary;

		/// <summary>
		/// Creates a new <see cref="LocalizationDictionary"/> object.
		/// </summary>
		/// <param name="cultureInfo">Culture of the dictionary</param>
		public LocalizationDictionary(CultureInfo cultureInfo)
		{
			CultureInfo = cultureInfo;
			dictionary = new Dictionary<string, LocalizedString>();
		}

		/// <inheritdoc/>
		public virtual LocalizedString GetOrNull(string name)
		{
			LocalizedString localizedString;
			return dictionary.TryGetValue(name, out localizedString) ? localizedString : null;
		}

		/// <inheritdoc/>
		public virtual IReadOnlyList<LocalizedString> GetAllStrings()
		{
			return dictionary.Values.ToImmutableList();
		}

		/// <inheritdoc/>
		public virtual IEnumerator<LocalizedString> GetEnumerator()
		{
			return GetAllStrings().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetAllStrings().GetEnumerator();
		}

		protected bool Contains(string name)
		{
			return dictionary.ContainsKey(name);
		}
	}
}
