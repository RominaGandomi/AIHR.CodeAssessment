using Workload.WebApi.Models;
using Workload.WebApi.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workload.WebApi.Interfaces
{
    public interface IWorkLoadApiService
    {
        public Task<List<CourceModel>> GetCources();

        public Task<List<WorkLoadHistoryModel>> GetWorkLoadHistory();
        public Task<bool> SaveWorkLoadHistory(WorkLoadCalculationDto model);
    }
}
