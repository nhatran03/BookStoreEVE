namespace BookStore.Localization.Sources
{
	/// <summary>
	/// A Localization Source is used to obtain localized strings.
	/// </summary>
	public interface ILocalizationSource
	{
		/// <summary>
		/// Unique Name of the source.
		/// </summary>
		string Name { get; }


	}
}
