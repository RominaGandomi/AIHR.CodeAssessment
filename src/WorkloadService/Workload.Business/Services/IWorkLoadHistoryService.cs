using Workload.Business.Entities;
using Workload.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Workload.Business.Services
{
    public interface IWorkLoadHistoryService : IRepository<WorkLoadHistory>
    {
        public Task<List<WorkLoadHistory>> GetAllFullyIncluded();
       
    }
}
