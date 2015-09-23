using System.Web.Http;
using Owin;

namespace WebServiceHost.Console
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            
            config
                .Routes
                .MapHttpRoute("Api v1.0", "api/{controller}/");

            appBuilder.UseWebApi(config);
        }
    }
}