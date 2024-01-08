namespace AkarSoftware.ApiBestPractise.Core.DTOs
{
    // base entity den kalıtım almadığımız için bunu bu şekilde sınıflandırıyoruz. 
    public class ProductFeatureDto
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int ProductId { get; set; }
    }
}
