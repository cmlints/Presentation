using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicAppFinal.Startup))]
namespace MusicAppFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
