using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookStoreEVE.Startup))]
namespace BookStoreEVE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
