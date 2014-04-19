using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookMgnt.Startup))]
namespace BookMgnt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
