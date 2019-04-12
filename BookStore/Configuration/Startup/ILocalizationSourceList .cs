using BookStore.Localization.Sources;
using System.Collections.Generic;

namespace BookStore.Configuration.Startup
{
	/// <summary>
	/// Defines a specialized list to store <see cref="ILocalizationSource"/> object.
	/// </summary>
	interface ILocalizationSourceList : IList<ILocalizationSource>
	{

	}
}
