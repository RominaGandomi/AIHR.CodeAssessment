using System;
using System.Collections.Generic;
using System.Text;

namespace Workload.Business.Entities
{
    public class WorkLoadHistoryCource : BaseEntity
    {
        public int CourceId { get; set; }
        public virtual Cource Cource { get; set; }

        public int WorkLoadHistoryId { get; set; }
        public virtual WorkLoadHistory WorkLoadHistory { get; set; }
        
    }
}
