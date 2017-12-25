using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRDbFirst.Startup))]
namespace HRDbFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
