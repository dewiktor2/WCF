using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeatherAppWebClient.Startup))]
namespace WeatherAppWebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
