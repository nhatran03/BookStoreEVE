using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BookStore.Modules
{
	/// <summary>
	/// Used to store all needed information for a module.
	/// </summary>
	public class BookStoreEVEModuleInfo
	{
		/// <summary>
		/// The assembly which contains the module definition.
		/// </summary>

		public Assembly Assembly { get; }

		/// <summary>
		/// Type of the module.
		/// </summary>
		public Type Type { get; }

		/// <summary>
		/// Instance of the module.
		/// </summary>
		public BookStoreEVEModule Instance { get; }

		/// <summary>
		/// Is this module loaded as a plugin.
		/// </summary>
		public bool IsLoadedAsPlugin { get; }

		/// <summary>
		/// All dependent modules of this module.
		/// </summary>
		public List<BookStoreEVEModuleInfo> Dependencies { get; }

		/// <summary>
		/// Creates a new BookStoreEVEModuleInfo object.
		/// </summary>
		public BookStoreEVEModuleInfo([NotNull] Type type, [NotNull] BookStoreEVEModule instance, bool isLoadedAsPlugin)
		{
			Check.NotNull(type, nameof(type));
			Check.NotNull(instance, nameof(instance));

			Type = type;
			Instance = instance;
			IsLoadedAsPlugin = isLoadedAsPlugin;
			Assembly = Type.GetType().Assembly;

			Dependencies = new List<BookStoreEVEModuleInfo>();
		}

		public override string ToString()
		{
			return Type.AssemblyQualifiedName ??
					Type.FullName;
		}
	}
}
