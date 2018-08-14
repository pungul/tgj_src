using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YesGuruji.Startup))]
namespace YesGuruji
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
