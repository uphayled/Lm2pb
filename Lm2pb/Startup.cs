using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lm2pb.Startup))]
namespace Lm2pb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
