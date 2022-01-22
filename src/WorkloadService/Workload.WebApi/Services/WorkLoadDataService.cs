using AutoMapper;
using Workload.Business.Entities;
using Workload.Business.Services;
using Workload.WebApi.Interfaces;
using Workload.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workload.WebApi.Services
{
    public class WorkLoadDataService : IWorkLoadDataService
    {
        private readonly ICourceService _courceService;
        private readonly IWorkLoadHistoryService _workLoadHistoryService;
        private readonly IWorkLoadHistoryCourcesService _workLoadHistoryCourcesService;
        private readonly IMapper _mapper;
        public WorkLoadDataService(
            ICourceService courceService,
            IMapper mapper,
            IWorkLoadHistoryService workLoadHistoryService,
            IWorkLoadHistoryCourcesService workLoadHistoryCourcesService)
        {
            _courceService = courceService;
            _mapper = mapper;
            _workLoadHistoryService = workLoadHistoryService;
            _workLoadHistoryCourcesService = workLoadHistoryCourcesService;
        }
        public async Task<List<Cource>> GetCources()
        {
            var data = await _courceService.GetAllAsync();
            return data;
        }

        public async Task<List<WorkLoadHistory>> GetWorkLoadHistory()
        {
            var data = await _workLoadHistoryService.GetAllIncluding(x => x.Cources).ToListAsync();
            foreach (var item in data)
            {
                item.Cources =  _workLoadHistoryCourcesService.GetAllIncluding(x=>x.Cource).Where(x => x.WorkLoadHistoryId == item.Id).ToList();
            }
            return data;
        }

        public async Task<WorkLoadHistory> SaveWorkLoadHistory(WorkLoadHistoryModel model)
        {
            var entity = _mapper.Map<WorkLoadHistory>(model);
            var result = await _workLoadHistoryService.AddAsync(entity);
            await _workLoadHistoryService.SaveAsync();
            return result;
        }
    }
}
