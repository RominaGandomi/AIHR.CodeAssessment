using System;
using System.Net;
using System.Threading.Tasks;
using Workload.WebApi.Helpers;
using Workload.WebApi.Models.Dto;
using Xunit;

namespace WorkLoadServiceTest.ControllerTest
{
    public class WorkloadFunctionalTest : TestBase
    {
        [Theory]
        [InlineData("01/01/2022", "01/01/2022", 16)]
        public async Task GetDailyWorkLoadWithValidFormat(string startDate, string endDate, double hours)
        {
            var actual = Helper.GetDailyWorkLoad(startDate, endDate, hours);
            var expected = 16.0;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("01/01/2022", "01/0sfd1/2022", 16)]
        public async Task GetDailyWorkLoadWithWrongFormat(string startDate, string endDate, double hours)
        {
            try
            {
                var workload = Helper.GetDailyWorkLoad(startDate, endDate, hours);
                Assert.True(false);
            }
            catch (FormatException)
            {
                Assert.True(true);
            }
        }
    }
}
