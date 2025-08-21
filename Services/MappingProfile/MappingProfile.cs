using AutoMapper;
using E_CommerceAPI.Models.Classes.ProductProperties;
using E_CommerceAPI.Models.DTOs;

namespace E_CommerceAPI.Services.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO, Product>().ForMember(dest => dest.Id, opt => opt.Ignore()).ForMember(dest => dest.Quantity, opt => opt.Ignore()).ReverseMap();

            CreateMap<DimensionsDTO, Dimensions>()
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.height))
                .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.width))
                .ReverseMap();


        }
    }
}
