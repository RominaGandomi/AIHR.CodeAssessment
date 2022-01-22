using System;
using System.Net;
using System.Threading.Tasks;
using Workload.WebApi.Helpers;
using Workload.WebApi.Models.Dto;
using Xunit;

namespace WorkLoadServiceTest.ControllerTest
{
    public class WorkLoadHistoryControllerTest : TestBase
    {
        [Theory]
        [InlineData("GET")]
        public async Task WorkLoadHistoryControllerGet(string method)
        {
            var request = CreateRequestMessage(method, $"/WorkLoadHistory");
            var response = await Client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
