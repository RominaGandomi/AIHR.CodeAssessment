using System;
using System.Collections.Generic;

namespace Workload.WebApi.Models.Dto
{
    public class WorkLoadCalculationDto
    {
        public WorkLoadCalculationDto()
        {
            Cources = new List<CourceItemDto>();
            StartDate = DateTime.Today.ToShortDateString();
            EndDate = DateTime.Today.ToShortDateString();
        }
        public List<CourceItemDto> Cources { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public double WorkLoad { get; set; }
    }
    public class CourceItemDto
    {
        public int Id { get; set; }
        public double Duration { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}
