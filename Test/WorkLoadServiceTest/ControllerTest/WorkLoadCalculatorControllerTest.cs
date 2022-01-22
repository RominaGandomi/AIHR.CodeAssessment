using System;
using System.Net;
using System.Threading.Tasks;
using Workload.WebApi.Models.Dto;
using Xunit;

namespace WorkLoadServiceTest.ControllerTest
{
    public class WorkLoadCalculatorControllerTest : TestBase
    {
        [Theory]
        [InlineData("GET")]
        public async Task WorkLoadCalculatorControllerGet(string method)
        {
            var request = CreateRequestMessage(method, $"/WorkLoadCalculator");
            var response = await Client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("Post")]
        public async Task WorkLoadCalculatorControllerPost(string method)
        {
            var model = new WorkLoadCalculationDto();
            var request = CreateRequestMessage(method, $"/WorkLoadCalculator",model);
            var response = await Client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
       
    }
}
