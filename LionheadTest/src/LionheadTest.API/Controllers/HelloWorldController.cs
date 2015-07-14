using System.Web.Http;

namespace LionheadTest.API.Controllers
{
    [RoutePrefix("api/helloWorld")]
    public class HelloWorldController : ApiController
    {
        [Route("")]
        public string Get()
        {
            return "Hello, World.";
        }
    }
}