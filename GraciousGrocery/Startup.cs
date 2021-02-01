using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GraciousGrocery.Startup))]
namespace GraciousGrocery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
