using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TodMovies.Startup))]
namespace TodMovies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
