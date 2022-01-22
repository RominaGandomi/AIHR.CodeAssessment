using System;
using System.Collections.Generic;
using System.Text;

namespace Workload.Business.Entities
{
    public class Cource : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
    }
}
