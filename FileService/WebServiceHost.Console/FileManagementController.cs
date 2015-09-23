using System.Web.Http;

namespace WebServiceHost.Console
{
    public class FileManagementController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            System.Console.WriteLine("Get() being called");
            return "Hello";
        }
    }
}