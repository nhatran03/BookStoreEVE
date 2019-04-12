﻿using BookStore.Configuration.Startup;
using BookStore.Dependency;
using BookStore.Extensions;
using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace BookStore.Localization.Dictionaries
{
	public class DictionaryBasedLocalizationSource : IDictionaryBasedLocalizationSource
	{

		public ILocalizationDictionaryProvider DictionaryProvider { get; private set; }

		/// <summary>
		/// Unique Name of the source.
		/// </summary>
		public string Name { get; }

		public void Extend(ILocalizationDictionary dictionary)
		{
			throw new NotImplementedException();
		}

		protected ILocalizationConfiguration LocalizationConfiguration { get; private set; }

		private ILogger logger;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="dictionaryProvider"></param>
		public DictionaryBasedLocalizationSource(string name, ILocalizationDictionaryProvider dictionaryProvider)
		{
			Check.NotNullOrEmpty(name, nameof(name));
			Check.NotNull(dictionaryProvider, nameof(dictionaryProvider));

			Name = name;
			DictionaryProvider = dictionaryProvider;
		}

		/// <inheritdoc/>
		public virtual void Initialize(ILocalizationConfiguration configuration, IIocResolver iocResolver)
		{
			LocalizationConfiguration = configuration;

			logger = iocResolver.IsRegistered(typeof(ILoggerFactory))
				? iocResolver.Resolve<ILoggerFactory>().Create(typeof(DictionaryBasedLocalizationSource))
				: NullLogger.Instance;

			DictionaryProvider.Initialize(Name);
		}

		/// <inheritdoc/>
		public string GetString(string name)
		{
			return GetString(name, CultureInfo.CurrentUICulture);
		}

		public string GetString(string name, CultureInfo culture)
		{
			var value = GetStringOrNull(name, culture);

			if(value == null)
			{
				return ReturnGivenNameOrThrowException(name, culture);
			}
			return value;
		}

		public string GetStringOrNull(string name, bool tryDefaults = true)
		{
			return GetStringOrNull(name, CultureInfo.CurrentUICulture, tryDefaults);
		}

		public string GetStringOrNull(string name, CultureInfo culture, bool tryDefaults = true)
		{
			var cultureName = culture.Name;
			var dictionaries = DictionaryProvider.Dictionaries;

			//Try to get from original dictionary (with country code)
			ILocalizationDictionary originalDictionary;
			if(dictionaries.TryGetValue(cultureName, out originalDictionary))
			{
				var strOriginal = originalDictionary.GetOrNull(name);
				if(strOriginal != null)
				{
					return strOriginal.Value;
				}
			}

			if (!tryDefaults)
			{
				return null;
			}

			//Try to get from same language dictionary (without country code)
			if(cultureName.Contains("-")) //Example: "tr-TR" (lenght=5)
			{
				ILocalizationDictionary langDictionary;
				if(dictionaries.TryGetValue(GetBaseCultureName(cultureName), out langDictionary))
				{
					var strLang = langDictionary.GetOrNull(name);
					if(strLang != null)
					{
						return strLang;
					}
				}
			}

			//Try to get from default language
			var defaultDictionary = DictionaryProvider.DefaultDictionary;
			if(defaultDictionary == null)
			{
				return null;
			}

			var strDefault = defaultDictionary.GetOrNull(name);
			if(strDefault == null)
			{
				return null;
			}

			return strDefault;
		}


		/// <inheritdoc/>
		public IReadOnlyList<LocalizedString> GetAllStrings(bool includeDefaults = true)
		{
			return GetAllStrings(CultureInfo.CurrentUICulture, includeDefaults);
		}

		/// <inheritdoc/>
		public IReadOnlyList<LocalizedString> GetAllStrings(CultureInfo culture, bool includeDefaults = true)
		{
			//TODO: Can be optimized (example: if it's already default dictionary, skip overriding)

			var dictionaries = DictionaryProvider.Dictionaries;

			//Create a temp dictionary to build
			var allStrings = new Dictionary<string, LocalizedString>();

			if (includeDefaults)
			{
				//Fill all strings from default dictionary
				var defaultDictionary = DictionaryProvider.DefaultDictionary;
				if (defaultDictionary != null)
				{
					foreach (var defaultDictString in defaultDictionary.GetAllStrings())
					{
						allStrings[defaultDictString.Name] = defaultDictString;
					}
				}

				//Overwrite all strings from the language based on country culture
				if (culture.Name.Contains("-"))
				{
					ILocalizationDictionary langDictionary;
					if (dictionaries.TryGetValue(GetBaseCultureName(culture.Name), out langDictionary))
					{
						foreach (var langString in langDictionary.GetAllStrings())
						{
							allStrings[langString.Name] = langString;
						}
					}
				}
			}

			//Overwrite all strings from the original dictionary
			ILocalizationDictionary originalDictionary;
			if (dictionaries.TryGetValue(culture.Name, out originalDictionary))
			{
				foreach (var originalLangString in originalDictionary.GetAllStrings())
				{
					allStrings[originalLangString.Name] = originalLangString;
				}
			}

			return allStrings.Values.ToImmutableList();
		}

		/// <summary>
		/// Extends the source with given dictionary.
		/// </summary>
		/// <param name="dictionary">Dictionary to extend the source</param>
		public virtual void Extend(ILocalizationDictionary dictionary)
		{
			DictionaryProvider.Extend(dictionary);
		}

		private virtual string ReturnGivenNameOrThrowException(string name, CultureInfo culture)
		{
			return LocalizationSourceHelper.ReturnGivenNameOrThrowException(
				LocalizationConfiguration,
				Name,
				name,
				culture,
				logger
			);
		}

		private static string GetBaseCultureName(string cultureName)
		{
			return cultureName.Contains("-")
				? cultureName.Left(cultureName.IndexOf("-", StringComparison.Ordinal))
				: cultureName;
		}
	}
}
