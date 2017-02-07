using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityCourseAndResultMangementSystem.Startup))]
namespace UniversityCourseAndResultMangementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
