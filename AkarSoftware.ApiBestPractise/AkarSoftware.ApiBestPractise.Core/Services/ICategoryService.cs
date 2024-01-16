using AkarSoftware.ApiBestPractise.Core.DTOs;
using AkarSoftware.ApiBestPractise.Core.Entities;

namespace AkarSoftware.ApiBestPractise.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<CostumeResponseDto<List<CategoryWithProductsDto>>> GetCategoryWithProductList();
        Task<CostumeResponseDto<CategoryWithProductsDto>> GetCategoryWithProductWithCategoryid(int id);

    }
}
