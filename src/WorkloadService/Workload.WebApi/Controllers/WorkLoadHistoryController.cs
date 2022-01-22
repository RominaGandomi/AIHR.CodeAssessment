using Workload.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Workload.WebApi.Controllers
{
    public class WorkLoadHistoryController : Controller
    {
        private readonly IWorkLoadApiService _workLoadApiService;
        public WorkLoadHistoryController(IWorkLoadApiService workLoadApiService)
        {
            _workLoadApiService = workLoadApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _workLoadApiService.GetWorkLoadHistory();
            return View(result);
        }
    }
}
