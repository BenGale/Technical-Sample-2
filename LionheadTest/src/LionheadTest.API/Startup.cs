using System.Web.Http;
using Owin;

namespace LionheadTest.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var configuration = new HttpConfiguration();
            configuration.MapHttpAttributeRoutes();

            appBuilder.UseWebApi(configuration);
        }
    }
}