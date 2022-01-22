using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Workload.WebApi;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace WorkLoadServiceTest
{
    public class TestBase
    {
        protected HttpClient Client { get; }
        public TestBase()
        {

            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .ConfigureAppConfiguration(builder =>
                builder.AddJsonFile("appsettings.json")
                .SetBasePath(Directory.GetCurrentDirectory()))
                .UseStartup<Startup>());
            Client = server.CreateClient();
        }

        protected HttpRequestMessage CreateRequestMessage(string method, string url, object body = null)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), url);
            if (body != null)
                request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            
            return request;
        }
    }
}
