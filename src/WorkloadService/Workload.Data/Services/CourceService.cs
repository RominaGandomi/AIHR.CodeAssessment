using Workload.Business.Entities;
using Workload.Business.Services;
using Workload.Data.Repositories;

namespace Workload.Data.Services
{
    public class CourceService : Repository<Cource>, ICourceService
    {
        public CourceService(CourcesDbContext context) : base(context)
        {

        }
    }
}
