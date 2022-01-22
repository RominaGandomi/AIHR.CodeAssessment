using AutoMapper;
using Workload.WebApi.Interfaces;
using Workload.WebApi.Models;
using Workload.WebApi.Models.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workload.WebApi.Services
{
    public class WorkLoadApiService : IWorkLoadApiService
    {
        private readonly IWorkLoadDataService _workLoadDataService;
        private readonly IMapper _mapper;
        public WorkLoadApiService(IWorkLoadDataService workLoadDataService, IMapper mapper)
        {
            _workLoadDataService = workLoadDataService;
            _mapper = mapper;
        }
      
        public async Task<List<CourceModel>> GetCources()
        {
            var result = await _workLoadDataService.GetCources();

            var output = _mapper.Map<List<CourceModel>>(result.ToList());
            return output;
        }

        public async Task<bool> SaveWorkLoadHistory(WorkLoadCalculationDto model)
        {
            var historyModel= _mapper.Map<WorkLoadHistoryModel>(model);

            foreach (var item in model.Cources.Where(x => x.IsSelected))
            {
                historyModel.Cources.Add(new WorkLoadHistoryCourceModel()
                {
                    CourceId=item.Id
                });
            }

            var result = await _workLoadDataService.SaveWorkLoadHistory(historyModel);
            var output = result.Id > 0 ? true : false;
            return output;
        }

        public async Task<List<WorkLoadHistoryModel>> GetWorkLoadHistory()
        {
            var result = await  _workLoadDataService.GetWorkLoadHistory();
            var output = _mapper.Map<List<WorkLoadHistoryModel>>(result.ToList());
            return output;
        }
    }
}
