using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Calorie_Counter.Startup))]
namespace Calorie_Counter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
