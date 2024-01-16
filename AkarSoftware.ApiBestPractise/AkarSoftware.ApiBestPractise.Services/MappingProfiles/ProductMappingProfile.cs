using AkarSoftware.ApiBestPractise.Core.DTOs;
using AkarSoftware.ApiBestPractise.Core.Entities;
using AutoMapper;

namespace AkarSoftware.ApiBestPractise.Services.MappingProfiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<Product, ProductWithCategoryDto>(); // iki yönlü map olmayacak

        }
    }
}
