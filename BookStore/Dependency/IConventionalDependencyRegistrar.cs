namespace BookStore.Dependency
{
	/// <summary>
	/// This interface is used to register dependencies by conventions. 
	/// </summary>
	/// <remarks>
	/// Implement this interface and register to <see cref="IocManager.AddConventionalRegistrar"/> method to be able
	/// to register classes by your own conventions.
	/// </remarks>
	interface IConventionalDependencyRegistrar
	{
	}
}
