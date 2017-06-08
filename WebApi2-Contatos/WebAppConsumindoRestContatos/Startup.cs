using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppConsumindoRestContatos.Startup))]
namespace WebAppConsumindoRestContatos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
