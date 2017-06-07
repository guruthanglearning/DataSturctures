using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Study_Angular.Startup))]
namespace Study_Angular
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
