namespace AkarSoftware.ApiBestPractise.Core.DTOs
{
    public class ProductWithCategoryDto : ProductDTO // ProductDto içerisindeki propertyler gelsin
    {
        public CategoryDto Category { get; set; }
    }
}
