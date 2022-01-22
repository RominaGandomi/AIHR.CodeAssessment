using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workload.WebApi.Models
{
    public class WorkLoadHistoryModel
    {

        public WorkLoadHistoryModel()
        {
            Cources = new List<WorkLoadHistoryCourceModel>();
        }
        public List<WorkLoadHistoryCourceModel> Cources { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double WorkLoad { get; set; }
    }
}
