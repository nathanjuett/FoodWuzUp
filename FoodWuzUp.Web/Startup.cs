using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodWuzUp.Web.Startup))]
namespace FoodWuzUp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
