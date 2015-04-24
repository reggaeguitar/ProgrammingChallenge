using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProgrammingChallenge.Startup))]
namespace ProgrammingChallenge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
