﻿using BookStore.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace BookStore.Localization.Dictionaries.Json
{
	/// <summary>
	///     This class is used to build a localization dictionary from json.
	/// </summary>
	/// <remarks>
	///     Use static Build methods to create instance of this class.
	/// </remarks>
	public class JsonLocalizationDictionary
	{
		/// <summary>
		///     Private constructor.
		/// </summary>
		/// <param name="cultureInfo">Culture of the dictionary</param>
		private JsonLocalizationDictionary(CultureInfo cultureInfo)
			: base(cultureInfo)
		{
		}

		/// <summary>
		///     Builds an <see cref="JsonLocalizationDictionary" /> from given file.
		/// </summary>
		/// <param name="filePath">Path of the file</param>
		public static JsonLocalizationDictionary BuildFromFile(string filePath)
		{
			try
			{
				return BuildFromJsonString(File.ReadAllText(filePath));
			}
			catch (Exception ex)
			{
				throw new BookStoreEVEException("Invalid localization file format! " + filePath, ex);
			}
		}

		/// <summary>
		///     Builds an <see cref="JsonLocalizationDictionary" /> from given json string.
		/// </summary>
		/// <param name="jsonString">Json string</param>
		public static JsonLocalizationDictionary BuildFromJsonString(string jsonString)
		{
			JsonLocalizationFile jsonFile;
			try
			{
				jsonFile = JsonConvert.DeserializeObject<JsonLocalizationFile>(
					jsonString,
					new JsonSerializerSettings
					{
						ContractResolver = new CamelCasePropertyNamesContractResolver()
					});
			}
			catch (JsonException ex)
			{
				throw new BookStoreEVEException("Can not parse json string. " + ex.Message);
			}

			var cultureCode = jsonFile.Culture;
			if (string.IsNullOrEmpty(cultureCode))
			{
				throw new BookStoreEVEException("Culture is empty in language json file.");
			}

			var dictionary = new JsonLocalizationDictionary(CultureInfoHelper.Get(cultureCode));
			var dublicateNames = new List<string>();
			foreach (var item in jsonFile.Texts)
			{
				if (string.IsNullOrEmpty(item.Key))
				{
					throw new BookStoreEVEException("The key is empty in given json string.");
				}

				if (dictionary.Contains(item.Key))
				{
					dublicateNames.Add(item.Key);
				}

				dictionary[item.Key] = item.Value.NormalizeLineEndings();
			}

			if (dublicateNames.Count > 0)
			{
				throw new BookStoreEVEException(
					"A dictionary can not contain same key twice. There are some duplicated names: " +
					dublicateNames.JoinAsString(", "));
			}

			return dictionary;
		}
	}
}
