using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TournamentTracker.Startup))]
namespace TournamentTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
