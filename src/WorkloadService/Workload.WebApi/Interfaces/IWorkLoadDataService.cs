using Workload.Business.Entities;
using Workload.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workload.WebApi.Interfaces
{
    public interface IWorkLoadDataService
    {
        public Task<List<WorkLoadHistory>> GetWorkLoadHistory();
        public Task<List<Cource>> GetCources();
        public Task<WorkLoadHistory> SaveWorkLoadHistory(WorkLoadHistoryModel model);
    }
}
