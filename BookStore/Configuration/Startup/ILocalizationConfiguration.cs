using BookStore.Localization;
using System.Collections.Generic;

namespace BookStore.Configuration.Startup
{
	/// <summary>
	/// Used for localization configurations.
	/// </summary>
	public interface ILocalizationConfiguration
	{

		IList<LanguageInfo> Languages { get; }


	}
}
