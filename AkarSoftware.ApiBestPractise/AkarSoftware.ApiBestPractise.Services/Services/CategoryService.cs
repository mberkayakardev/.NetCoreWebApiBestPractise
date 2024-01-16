using AkarSoftware.ApiBestPractise.Core.DTOs;
using AkarSoftware.ApiBestPractise.Core.Entities;
using AkarSoftware.ApiBestPractise.Core.Repositories;
using AkarSoftware.ApiBestPractise.Core.Services;
using AkarSoftware.ApiBestPractise.Core.UnitOfWorks;
using AutoMapper;

namespace AkarSoftware.ApiBestPractise.Services.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CostumeResponseDto<List<CategoryWithProductsDto>>> GetCategoryWithProductList()
        {
            var result = await _categoryRepository.GetCategoryWithProductsAsync();
            if (result == null || result.Count == 0)
                return CostumeResponseDto<List<CategoryWithProductsDto>>.FailResult("Category Mevcut Değil", 404);

            var MappingResult = _mapper.Map<List<CategoryWithProductsDto>>(result);

            return CostumeResponseDto<List<CategoryWithProductsDto>>.SuccessResult(200, MappingResult);

        }

        public async Task<CostumeResponseDto<CategoryWithProductsDto>> GetCategoryWithProductWithCategoryid(int id)
        {
            var result = await _categoryRepository.GetCategoryWithProductsByIdAsync(id);
            if (result == null )
                return CostumeResponseDto<CategoryWithProductsDto>.FailResult("Category Mevcut Değil", 404);

            var MappingResult = _mapper.Map<CategoryWithProductsDto>(result);

            return CostumeResponseDto<CategoryWithProductsDto>.SuccessResult(200, MappingResult);
        }
    }
}
