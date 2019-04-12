using System;
using System.Collections.Generic;
using System.Globalization;

namespace BookStore.Localization.Dictionaries
{
	public class LocalizationDictionary : ILocalizationDictionary
	{
		public virtual string this[string name]
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public CultureInfo CultureInfo{ get; private set; }

		public IReadOnlyList<LocalizedString> GetAllStrings()
		{
			throw new NotImplementedException();
		}

		public LocalizedString GetOrNull(string name)
		{
			throw new NotImplementedException();
		}
	}
}
