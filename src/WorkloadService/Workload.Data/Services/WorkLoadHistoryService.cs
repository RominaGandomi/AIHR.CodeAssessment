using Workload.Business.Entities;
using Workload.Business.Services;
using Workload.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workload.Data.Services
{
    public class WorkLoadHistoryService : Repository<WorkLoadHistory>, IWorkLoadHistoryService
    {
        public WorkLoadHistoryService(CourcesDbContext context) : base(context)
        {
           
           
        }

        public Task<List<WorkLoadHistory>> GetAllFullyIncluded()
        {
            throw new System.NotImplementedException();
        }
    }
}
