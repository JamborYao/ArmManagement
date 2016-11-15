using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ARMTemplate.Startup))]
namespace ARMTemplate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
