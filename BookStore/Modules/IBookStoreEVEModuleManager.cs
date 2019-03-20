using System;
using System.Collections.Generic;

namespace BookStore.Modules
{
	interface IBookStoreEVEModuleManager
	{
		BookStoreEVEModuleInfo StartupModule { get; }

		IReadOnlyList<BookStoreEVEModuleInfo> Modules { get; }

		void Initialize(Type startupModule);

		void StartModules();

		void ShutdownModules();
	}
}
