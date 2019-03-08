using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BookStore.Reflection.Extensions
{
	internal static class AssemblyHelper
	{
		public static List<Assembly> GetAllAssembliesInFolder(string folderPath, SearchOption searchOption)
		{
			var essemblyFiles = Directory
				.EnumerateFiles(folderPath, "*.*", searchOption)
				.Where(s => s.EndsWith(".dll") || s.EndsWith(".exe"));

			return essemblyFiles.Select(
				Assembly.LoadFile
				).ToList();
		}
	}
}
