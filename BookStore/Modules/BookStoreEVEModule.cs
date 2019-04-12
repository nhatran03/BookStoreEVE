using BookStore.Dependency;

namespace BookStore.Modules
{
	/// <summary>
	/// This class must be implemented by all module definition classes.
	/// </summary>
	/// <remarks>
	/// A module definition class is generally located in it's own assembly
	/// and implements some action in module events on application startup and shutdown.
	/// It also defines depended modules.
	/// </remarks>
	public abstract class BookStoreEVEModule
	{
		protected internal IIocManager IocManager { get; internal set; }

	}
}
