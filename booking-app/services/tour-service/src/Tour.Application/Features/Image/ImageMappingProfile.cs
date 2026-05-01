using Application.Common;
using AutoMapper;
using Domain.Entities;
using Shared.Infrastructure;

namespace Application.Features
{
    public class ImageMappingProfile : Profile
    {
        public ImageMappingProfile()
        {
            // 1. Map từ Command sang Entity 
            CreateMap<UploadImagesRequestDTO, Image>()
            .ForMember(dest => dest.created_date, opt => opt.MapFrom(src => DatetimeExtension.ConvertDatetimeVN()))
            .ForMember(dest => dest.travel_tour_id, opt => opt.MapFrom(src => src.travel_tour_id))
            .ForMember(dest => dest.created_by, opt => opt.MapFrom(src => src.user_id));

            CreateMap<CloudinaryResponse, Image>()
            .ForMember(dest => dest.url, opt => opt.MapFrom(src => src.Url.ToString()))
            .ForMember(dest => dest.public_id, opt => opt.MapFrom(src => src.PublicId))
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<SetMainImageRequestDTO, Image>()
            .ForMember(dest => dest.is_primary, opt => opt.MapFrom(src => src.is_primary))
            .ForMember(dest => dest.updated_date, opt => opt.MapFrom(src => DatetimeExtension.ConvertDatetimeVN()));
            // 2. Map từ Entity sang DTO   
        }

    }
}