using System.Linq.Expressions;

namespace AkarSoftware.ApiBestPractise.Core.Repositories
{
    /// <summary>
    ///  Veritabanına yapacağım tüm temel sorguları ekleyeceğim 
    /// </summary>
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id); // Task ile asenkroinik bir method olması sağlandı gerite T dönülecek
        Task<IEnumerable<T>> GetAllAsync (); // IEnumerable dönmememizin sebebi ise order by vs gibi yapılar kullanabiliriz bu istekle yapılmıştır. 
        IQueryable<T> Where(Expression<Func<T,bool>> expression); // (Where sorgusu olabilir) IQueryasble Yazmış olduğun sorgular direk veritabanına gitmez.
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression); // Any ile böyle bir kayıt varmı yokmu onu gözlemleriz.
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> Entities); // interface almamamız önemli soyut nesneler ile çalışınız. bunu IEnumerable interface ini implemente etmiş değerlere cast edebilmek için 
        void Update (T entity);
        void Delete (T entity);
        void RemoveRange(IEnumerable<T> Entitites);
        
        // IQueryable ile where gibi sorgusu olabilir geriye bir Iqueryable dönerim.
        // IQueryable ile yazılan sorgular veritabanına gitmez, tolist, tolist async gibi methodlar ile veritabanına gidebilir
        // where ile yazılan sorgu içerisinde daha komplex sorgular için daha performanslı çalışabilirim.
        // Daha performanslı bir şekilde çalışabilmek için 
        // Veritabanına yapılacak olan sorguyu yazmak
        // tip list olsaydı sadece where ile işlem yapardık sonrasında bu veri veritabanından çekilirdi bundan sonra yapacağımız 
        // linq işlemleri memory e alınmış veriler için gerçekleştirilecektir
        // Where yazıyoruz çünkü amaç veritabanına gidecek bir sorguyu hazırlıyoruz
        // Expression tanımlamak (x=> x.id >6) gibi sorgular yazabilmemizi sağlar
        // Queryable dönmesi ile birlikte order by gibi devam sorguları yazabiliriz. 
        // List yapsaydık where kadarki kısmı db ye yansırıt gelen veri memory e alınır ve sonrasında 
        // memory datası üzerinde işlem yapmış oluruz. 
        // where için Expression yazıyoruz
        // EF coredaki sorgular Expression alır

        // Function delegate aldı T ile generic aldı ve geriye bool sonuç dönecektir .


    }
}
