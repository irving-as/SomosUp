using AcopioUP.Dtos;
using AcopioUP.Models;
using AutoMapper;

namespace AcopioUP
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            CreateMap<Product, ProductDto>();


            // Dto to Domain
            CreateMap<ProductDto, Product>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.ImgSrc, opt => opt.Ignore());
        }
    }
}