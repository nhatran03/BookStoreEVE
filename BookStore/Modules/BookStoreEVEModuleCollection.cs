using System;
using System.Collections.Generic;

namespace BookStore.Modules
{
	/// <summary>
	/// Used to store StudioXModuleInfo objects as a dictionary.
	/// </summary>
	internal class BookStoreEVEModuleCollection : List<BookStoreEVEModuleInfo>
	{
		public Type StartupModuleType { get; }

		public BookStoreEVEModuleCollection(Type startupModuleType)
		{
			StartupModuleType = startupModuleType;
		}
	}
}
