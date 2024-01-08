namespace AkarSoftware.ApiBestPractise.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; } // Fiyat SSSSSSSSSSS
        public int CategoryId { get; set; } // Foregn key |  1 e çok bir ilişki olması | 
        public Category Category { get; set; }
        public ProductFeature Feature { get; set; }
    }
}
