using AutoMapper;
using Workload.Business.Entities;
using Workload.WebApi.Models;
using Workload.WebApi.Models.Dto;
using System;
using System.Collections.Generic;

namespace Workload.WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;

            CreateMap<CourceModel, Cource>();
            CreateMap<Cource, CourceModel>();

            CreateMap<WorkLoadHistoryModel, WorkLoadHistory>();
            CreateMap<WorkLoadHistory, WorkLoadHistoryModel>();

            CreateMap<CourceModel, CourceItemDto>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(src => $"{src.Name} ( {src.Duration} Hours) "))
              .ForMember(dest => dest.IsSelected, opt => opt.MapFrom(src => false))
              ;


            CreateMap<WorkLoadCalculationDto, WorkLoadHistoryModel>()
              .ForMember(dest => dest.Cources, opt => opt.MapFrom(src => new List<WorkLoadHistoryCourceModel>()))
              .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateTime.Parse(src.StartDate)))
              .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => DateTime.Parse(src.EndDate)))
              .ForMember(dest => dest.WorkLoad, opt => opt.MapFrom(src => src.WorkLoad))
              ;

            CreateMap<CourceItemDto, CourceModel>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
              ;

            CreateMap<WorkLoadHistoryCourceModel, WorkLoadHistoryCource>();
            CreateMap<WorkLoadHistoryCource, WorkLoadHistoryCourceModel>();
        }
    }
}
