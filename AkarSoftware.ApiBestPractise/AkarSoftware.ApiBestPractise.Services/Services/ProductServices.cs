using AkarSoftware.ApiBestPractise.Core.DTOs;
using AkarSoftware.ApiBestPractise.Core.Entities;
using AkarSoftware.ApiBestPractise.Core.Repositories;
using AkarSoftware.ApiBestPractise.Core.Services;
using AkarSoftware.ApiBestPractise.Core.UnitOfWorks;
using AutoMapper;

namespace AkarSoftware.ApiBestPractise.Services.Services
{
    // Başka Katmanlardan Erişilebilsin
    // Generic Service alınacak tıpkı repository de olduğu gibi.
    // Gelen Generic Methodları alacak ardından da IProductService ten gelen methodlar alınacaktır. 

    public class ProductServices : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository; // artık biz Generic repository değil ProductRepository i almamaız gerekecektir. Generic bu sebeple base te private tanımlanmıştır. bu repository işimizi görmüyor. sadece generic methodları içerir.
        private readonly IMapper _mapper; // mapleme işlemleri için ilgili alan lazım olacaktır. 
        public ProductServices(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CostumeResponseDto<List<ProductWithCategoryDto>>> GetListProductsWithCategories()
        {
            var RepositoryData = await _productRepository.GetListProductsWithCategoriesAsync(); // List<Product> döner mapper ile dönüşüm sağlanacaktır. 
            if (RepositoryData == null ||RepositoryData.Count == 0)
                return CostumeResponseDto<List<ProductWithCategoryDto>>.FailResult("Product Bulunamadı", 404);
            
            var mappedData = _mapper.Map<List<ProductWithCategoryDto>>(RepositoryData); // Dönüştü. 
            return CostumeResponseDto<List<ProductWithCategoryDto>>.SuccessResult(200, mappedData);

        }

        public async Task<CostumeResponseDto<ProductWithCategoryDto>> GetProductsWithCategory(int id)
        {
            var RepositoryData = await _productRepository.GetProductsWithCategoryAsync(id);
            if (RepositoryData == null )
                return CostumeResponseDto<ProductWithCategoryDto>.FailResult("Product bulunamadı", 404);
            
            var mappedData = _mapper.Map<ProductWithCategoryDto>(RepositoryData);
            return CostumeResponseDto<ProductWithCategoryDto>.SuccessResult(200, mappedData);
        }
    }
}
