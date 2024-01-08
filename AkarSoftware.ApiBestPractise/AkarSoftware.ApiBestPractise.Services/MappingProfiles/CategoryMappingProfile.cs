using AkarSoftware.ApiBestPractise.Core.DTOs;
using AkarSoftware.ApiBestPractise.Core.Entities;
using AutoMapper;

namespace AkarSoftware.ApiBestPractise.Services.MappingProfiles
{
    internal class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();

        }
    }
}
