using System.Web.Http;
using LionheadTest.API.IoC;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;

namespace LionheadTest.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var configuration = new HttpConfiguration();
            configuration.MapHttpAttributeRoutes();

            var kernel = new StandardKernel(
                new ConfigurationModule());

            appBuilder.UseNinjectMiddleware(() => kernel);
            appBuilder.UseNinjectWebApi(configuration);
        }
    }
}