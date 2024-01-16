using AkarSoftware.ApiBestPractise.Core.DTOs;
using AkarSoftware.ApiBestPractise.Core.Entities;

namespace AkarSoftware.ApiBestPractise.Core.Services
{
    // generic service içerisinde yer alan methodlarım gelsin diye bu şekilde ilgili geliştirme yapıldı. 

    public interface IProductService : IService<Product>
    {
        Task<CostumeResponseDto<ProductWithCategoryDto>> GetProductsWithCategory(int id);
        Task<CostumeResponseDto<List<ProductWithCategoryDto>>> GetListProductsWithCategories();
    }
}
