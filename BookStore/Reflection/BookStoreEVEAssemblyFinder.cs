using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BookStore.Reflection
{
	class BookStoreEVEAssemblyFinder : IAssemblyFinder
	{
		private readonly IBookStoreEVEModuleManager moduleManager;

		public BookStoreEVEAssemblyFinder(IBookStoreEVEModuleManager moduleManager)
		{
			this.moduleManager = moduleManager;
		}

		public List<Assembly> GetAllAssemblies()
		{
			var assemblies = new List<Assembly>();

			foreach (var module in moduleManager.Modules)
			{
				assemblies.Add(module.Assembly);
				assemblies.AddRange(module.Instance.GetAdditionalAssemblies());
			}

			return assemblies.Distinct().ToList();
		}
	}
}
