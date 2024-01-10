using AkarSoftware.ApiBestPractise.Core.DTOs;
using AkarSoftware.ApiBestPractise.Core.Entities;
using AkarSoftware.ApiBestPractise.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AkarSoftware.ApiBestPractise.API.Controllers
{
    public class ProductsController : CostumeBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _ProductService;
        public ProductsController(IMapper mapper, IService<Product> productService)
        {
            _mapper = mapper;
            _ProductService = productService;
        }

        // host/api/productss
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var result = await _ProductService.GetAllAsync();  
            var ProductDtos = _mapper.Map<List<ProductDTO>>(result.ToList());  
            return CreateActionResult(CostumeResponseDto<List<ProductDTO>>.SuccessResult(200, ProductDtos));
        }

        // id şeklide bu şekilde belirtirsek query string değil parametreden alacağımızı belirtrizi host/api/products/3 gibi bir istek yapılmaı
        // id yi belirtmezsek query string ten bekler. süslü parantez ile belirtirsek burayı bir route olarak algılayacaktır. 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _ProductService.GetByIdAsync(id);
            var ProductDtos = _mapper.Map<ProductDTO>(result);
            return CreateActionResult(CostumeResponseDto<ProductDTO>.SuccessResult(200, ProductDtos));
        }

        [HttpPost] // Post işlemi gerçekleştirilecektir. 
        public async Task<IActionResult> CreateProduct(ProductDTO productDTO)
        {
            var Model = _mapper.Map<Product>(productDTO);
            var result = await _ProductService.AddAsync(Model);
            var resultmodel = _mapper.Map<ProductDTO>(result);
            return CreateActionResult(CostumeResponseDto<ProductDTO>.SuccessResult(201, resultmodel));

            // Hatırlanacağı üzere bizler kullanıcıdan Dto alıyoruz bu dto yu model e mapledikten sone yine model i değil sadece ve sadece DTO dönmemiz gerekiyor.
            // Bu sebepten ötürü iki defa maplenme gereksinimi duyulldu 
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDTO productDTO)
        {
            var Model = _mapper.Map<Product>(productDTO);
            await _ProductService.Update(Model);
            return CreateActionResult(CostumeResponseDto<NoContentDto>.SuccessResult(204));

            // Hatırlanacağı üzere bizler kullanıcıdan Dto alıyoruz bu dto yu model e mapledikten sone yine model i değil sadece ve sadece DTO dönmemiz gerekiyor.
            // Bu sebepten ötürü iki defa maplenme gereksinimi duyulldu 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var model = await _ProductService.GetByIdAsync(id);
            await _ProductService.Delete(model);
            return CreateActionResult(CostumeResponseDto<NoContentDto>.SuccessResult(204));

        }

    }
}
