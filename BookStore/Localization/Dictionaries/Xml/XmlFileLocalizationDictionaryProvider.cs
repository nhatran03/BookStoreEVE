﻿using System.IO;

namespace BookStore.Localization.Dictionaries.Xml
{
	/// <summary>
	/// Provides localization dictionaries from XML files in a directory.
	/// </summary>
	public class XmlFileLocalizationDictionaryProvider : LocalizationDictionaryProviderBase
	{
		private readonly string directoryPath;

		/// <summary>
		/// Creates a new <see cref="XmlFileLocalizationDictionaryProvider"/>.
		/// </summary>
		/// <param name="directoryPath">Path of the dictionary that contains all related XML files</param>
		public XmlFileLocalizationDictionaryProvider(string directoryPath)
		{
			this.directoryPath = directoryPath;
		}

		public override void Initialize(string sourceName)
		{
			var fileNames = Directory.GetFiles(directoryPath, "*.xml", SearchOption.TopDirectoryOnly);

			foreach (var fileName in fileNames)
			{
				var dictionary = CreateXmlLocalizationDictionary(fileName);
				if (Dictionaries.ContainsKey(dictionary.CultureInfo.Name))
				{
					throw new BookStoreEVEInitializationException(sourceName + " source contains more than one dictionary for the culture: " + dictionary.CultureInfo.Name);
				}

				Dictionaries[dictionary.CultureInfo.Name] = dictionary;

				if (fileName.EndsWith(sourceName + ".xml"))
				{
					if (DefaultDictionary != null)
					{
						throw new BookStoreEVEInitializationException("Only one default localization dictionary can be for source: " + sourceName);
					}

					DefaultDictionary = dictionary;
				}
			}
		}

		protected virtual XmlLocalizationDictionary CreateXmlLocalizationDictionary(string fileName)
		{
			return XmlLocalizationDictionary.BuildFomFile(fileName);
		}
	}
}
