using AkarSoftware.ApiBestPractise.Core.Entities;

namespace AkarSoftware.ApiBestPractise.Core.DTOs
{
    public class ProductDTO : BaseDto
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }  
        public int CategoryId { get; set; }  
    }
}
