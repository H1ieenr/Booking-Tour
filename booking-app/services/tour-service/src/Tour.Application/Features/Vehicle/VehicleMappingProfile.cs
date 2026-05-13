using Application.Common;
using AutoMapper;
using Domain.Entities;

namespace Application.Features
{
    public class VehicleMappingProfile : Profile
    {
        public VehicleMappingProfile()
        {
            // 1. Map từ Command sang Entity 
            CreateMap<CreateVehicleRequestDTO, Vehicle>()
            .ForMember(dest => dest.created_date, opt => opt.MapFrom(src => DatetimeExtension.ConvertDatetimeVN()))
            .ForMember(dest => dest.created_by, opt => opt.MapFrom(src => src.user_id));
            CreateMap<UpdateVehicleRequestDTO, Vehicle>()
            .ForMember(dest => dest.updated_date, opt => opt.MapFrom(src => DatetimeExtension.ConvertDatetimeVN()))
            .ForMember(dest => dest.updated_by, opt => opt.MapFrom(src => src.user_id));
            CreateMap<DeleteVehicleRequestDTO, Vehicle>()
            .ForMember(dest => dest.updated_date, opt => opt.MapFrom(src => DatetimeExtension.ConvertDatetimeVN()))
            .ForMember(dest => dest.updated_by, opt => opt.MapFrom(src => src.user_id))
            .ForMember(dest => dest.is_deleted, opt => opt.MapFrom(src => true));
            // 2. Map từ Entity sang DTO 
        }

    }
}