using System;
using System.Collections.Generic;
using System.Text;

namespace Workload.Business.Entities
{
    public class WorkLoadHistory:BaseEntity
    {
        public WorkLoadHistory()
        {
            Cources = new List<WorkLoadHistoryCource>();
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double WorkLoad { get; set; }

        public virtual List<WorkLoadHistoryCource> Cources { get; set; }
    }
}
