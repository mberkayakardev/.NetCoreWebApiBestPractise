using AkarSoftware.ApiBestPractise.Core.DTOs;
using AkarSoftware.ApiBestPractise.Core.Entities;
using AutoMapper;

namespace AkarSoftware.ApiBestPractise.Services.MappingProfiles
{
    public class ProductFeatureMappingProfile: Profile
    {
        public ProductFeatureMappingProfile()
        {
            CreateMap<ProductFeatureDto, ProductFeature>().ReverseMap();
        }
    }
}
