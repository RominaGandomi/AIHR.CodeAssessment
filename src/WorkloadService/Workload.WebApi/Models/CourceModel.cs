using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workload.WebApi.Models
{
    public class CourceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
    }
}
