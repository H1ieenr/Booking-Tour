using AutoMapper;
using Domain.Entities;

namespace Tour.Application
{
    public class TravelTourMappingProfile : Profile
    {
        public TravelTourMappingProfile()
        {
            // 1. Map từ Command sang Entity 
            CreateMap<CreateTravelTourRequestDto, TravelTour>();
            

            // 2. Map từ Entity sang DTO 
            CreateMap<TravelTour, GetTravelTourByIdDTO>();
        }
    }
}