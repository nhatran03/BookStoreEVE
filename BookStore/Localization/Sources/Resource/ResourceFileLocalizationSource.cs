using BookStore.Configuration.Startup;
using BookStore.Dependency;
using Castle.Core.Logging;
using System.Resources;

namespace BookStore.Localization.Sources.Resource
{
	public class ResourceFileLocalizationSource : ILocalizationSource, ISingletonDependency
	{
		/// <summary>
		/// Unique Name of the source.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Reference to the <see cref="ResourceManager"/> object related to this localization source.
		/// </summary>
		public ResourceManager ResourceManager { get; }

		private ILogger logger;

		/// <param name="name">Unique Name of the source</param>
		/// <param name="resourceManager">Reference to the <see cref="ResourceManager"/> object related to this localization source</param>
		public ResourceFileLocalizationSource(string name, ResourceManager resourceManager)
		{
			this.Name = name;
			this.ResourceManager = resourceManager;
		}

		/// <summary>
		/// This method is called by BookStore before first usage.
		/// </summary>
		
		public virtual void Initialize(ILocalizationConfiguration configuration, IIocResolver iocResolver)
		{

		}
	}
}
