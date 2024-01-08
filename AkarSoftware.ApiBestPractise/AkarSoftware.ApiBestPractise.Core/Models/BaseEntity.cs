namespace AkarSoftware.ApiBestPractise.Core.Entities
{
    /// <summary>
    /// Tüm veritabanı tablolarında olması gereken belli başlı propertyler dir. 
    /// 
    /// Abstract yapmamızın sebebi buradan bir nesne örnepi alınmasın
    /// </summary>
    public abstract class BaseEntity // başka assemblylerden (class library) erişebilmemiz için 
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
