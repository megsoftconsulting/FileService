using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace WebServiceHost.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // http://localhost:9000/api/FileManagement/ 

            var baseAddress = "http://localhost:9000/";

            using (WebApp.Start<Startup>(baseAddress))
            {
                System.Console.WriteLine("Hosting WebAPI");
                // Create HttpCient and make a request to api/values 
                var client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/FileManagement").Result;

                System.Console.WriteLine(response);
                System.Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                while (true)
                {
                }
            }
        }
    }
}