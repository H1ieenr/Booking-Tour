using Application.Common;
using AutoMapper;
using Domain.Entities;

namespace Application.Features
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            // 1. Map từ Command sang Entity 
            CreateMap<CreateCategoryRequestDTO, Category>()
            .ForMember(dest => dest.created_date, opt => opt.MapFrom(src => DatetimeExtension.ConvertDatetimeVN()));
            CreateMap<UpdateCategoryRequestDTO, Category>()
            .ForMember(dest => dest.updated_date, opt => opt.MapFrom(src => DatetimeExtension.ConvertDatetimeVN()));
            CreateMap<DeleteCategoryRequestDTO, Category>()
            .ForMember(dest => dest.updated_date, opt => opt.MapFrom(src => DatetimeExtension.ConvertDatetimeVN()))
            .ForMember(dest => dest.is_deleted, opt => opt.MapFrom(src => true));
            // 2. Map từ Entity sang DTO 
        }
    }
}