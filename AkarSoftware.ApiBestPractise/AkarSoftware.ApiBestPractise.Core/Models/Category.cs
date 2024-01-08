namespace AkarSoftware.ApiBestPractise.Core.Entities
{
    /// <summary>
    /// Entitylerim BaseEntity den miras alacaktır.
    /// </summary>
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; } // Referasn verdiğimiz propertyler navigation propertylerdir. 
                                                           // category ile product arası geçişler için kullanacağım yapı

    }
}
