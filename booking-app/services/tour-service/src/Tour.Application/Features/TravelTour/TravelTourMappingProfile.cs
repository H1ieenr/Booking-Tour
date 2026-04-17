using System;
using Application.Common;
using AutoMapper;
using Domain.Entities;

namespace Application.Features
{
    public class TravelTourMappingProfile : Profile
    {
        public TravelTourMappingProfile()
        {
            // 1. Map từ Command sang Entity 
            CreateMap<CreateTravelTourRequestDTO, TravelTour>()
            .ForMember(dest => dest.created_date, opt => opt.MapFrom(src => DatetimeExtension.ConvertDatetimeVN()));;

            // 2. Map từ Entity sang DTO   
            CreateMap<TravelTour, GetTravelTourByIdDTO>();
        }
    }
}