using AkarSoftware.ApiBestPractise.API.Filters;
using AkarSoftware.ApiBestPractise.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AkarSoftware.ApiBestPractise.API.Controllers
{
    public class CategoriesController : CostumeBaseController 
        // Route ve Api controller i içerisinde barındıran base controller aynı zamanda Costume dönüşte mevcut
    {
        private readonly ICategoryService _CategoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _CategoryService = categoryService;
        }

        // Api/Categories/MethodAdi
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategoryWithProducts() 
        {
            var result = await _CategoryService.GetCategoryWithProductList();
            return CreateActionResult(result);
        
        }

        // Api/Categories/MethodAdi/2
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCategoryWithProducts(int id)
        {
            var result = await _CategoryService.GetCategoryWithProductWithCategoryid(id);
            return CreateActionResult(result);
        }

    }
}
