using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workload.WebApi.Models
{
    public class WorkLoadHistoryCourceModel
    {
        public int Id { get; set; }
        public int CourceId { get; set; }

        public CourceModel Cource { get; set; }

        public int WorkLoadHistoryId { get; set; }
        public WorkLoadHistoryModel WorkLoadHistory { get; set; }

    }
}
