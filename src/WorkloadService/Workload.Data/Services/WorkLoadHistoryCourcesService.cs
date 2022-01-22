using Workload.Business.Entities;
using Workload.Business.Services;
using Workload.Data.Repositories;

namespace Workload.Data.Services
{
    public class WorkLoadHistoryCourcesService : Repository<WorkLoadHistoryCource>, IWorkLoadHistoryCourcesService
    {
        public WorkLoadHistoryCourcesService(CourcesDbContext context) : base(context)
        {

        }
    }
}
