using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AR.Startup))]
namespace AR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
