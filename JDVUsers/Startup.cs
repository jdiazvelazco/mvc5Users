using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JDVUsers.Startup))]
namespace JDVUsers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
