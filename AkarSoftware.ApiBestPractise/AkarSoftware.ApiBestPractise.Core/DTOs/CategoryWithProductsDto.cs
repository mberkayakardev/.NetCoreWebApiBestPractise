namespace AkarSoftware.ApiBestPractise.Core.DTOs
{
    public class CategoryWithProductsDto : CategoryDto
    {
        public List<ProductDTO> Products { get; set; }  
    }

}
