using AutoMapper;
using Workload.WebApi.Helpers;
using Workload.WebApi.Interfaces;
using Workload.WebApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workload.WebApi.Controllers
{
    public class WorkLoadCalculatorController: Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWorkLoadApiService _workLoadApiService;
        private readonly IMapper _mapper;
        public WorkLoadCalculatorController(ILogger<HomeController> logger, IWorkLoadApiService workLoadApiService, IMapper mapper)
        {
            _logger = logger;
            _workLoadApiService = workLoadApiService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var output = new WorkLoadCalculationDto();
            var result = await _workLoadApiService.GetCources();
            output.Cources = _mapper.Map<List<CourceItemDto>>(result);
            return View(output);
        }

        [HttpPost]
        public async Task<IActionResult> Index(WorkLoadCalculationDto model)
        {
            var totalHours = model.Cources.Where(x => x.IsSelected).Sum(x => x.Duration);
            model.WorkLoad = Helper.GetDailyWorkLoad(model.StartDate, model.EndDate, totalHours);

            var result = await _workLoadApiService.SaveWorkLoadHistory(model);
            return View(model);
        }
    }
}
