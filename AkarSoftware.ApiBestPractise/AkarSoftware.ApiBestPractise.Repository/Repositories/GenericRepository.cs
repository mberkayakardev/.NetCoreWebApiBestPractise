using AkarSoftware.ApiBestPractise.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AkarSoftware.ApiBestPractise.Repository.Repositories
{
    // business ten erişilebilmesi için public yapıldı. 
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _appDbContext;
        // Costume repositorylere kalıtım verildiğinde ilgili alana ulaşabilmek için protected yapıldı.
        // ilerde bazen sadece ilgili entity e ait temel crud operasyonlar haricinde özel methodlara extra methodlara ihtiyaç duyulursa
        // Product ile ilgili feature leri alabilmek vs gibi özel ProductService, ProductRepostiory gibi yapılarıda eklemem gerekecektir.
        // miras alacağım yerlerde bu dbcontext e erişebilmem gerekmektedir. 
        // protexted miras alınan sınıflardan erişilebilir
        private readonly DbSet<T> _Entity; // Entity me , veritabanındaki tablolarıma karşılık gelir. 
        // Readonly olarak tanımlandığında değişkenler ya üretildiği yerde yada constuctor içerisinde değer atanabilmesi için işlem yapıldı.
        // sonradan set edilip değiştirilememesi için bu şekilde işlem yapıyoruz.

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _Entity = _appDbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _Entity.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> Entities)
        {
            await _Entity.AddRangeAsync(Entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _Entity.AnyAsync(expression);
        }

        public void Delete(T entity)
        {
            _Entity.Remove(entity);
        }

        // datayı filtreledikten sonra order by gibi queryleri devam ettirmek için 
        // GetAll Methodu IQueryAble döner. Dbsest üzerinden asnotracikng ile takipi önledik.
        // Queryable ile data üzerinde ilgii sorgularumuzu çevirebilmek için
        // EF Core çekmiş olduğu dataları track etmesin Anlık olarak durumlarını izlemesin diye bu şekilde bir işlem yapıldı. 
        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _Entity.AsNoTracking().AsQueryable();
        }

        // findasync bir primary key beklenir
        public async Task<T> GetByIdAsync(int id)
        {
            return await _Entity.FindAsync(id);
        }

        // Remove asenkron değil. Çünkü Remove Db den silmez sadece state i değiştirir. deleted yapar flag koyar.
        public void RemoveRange(IEnumerable<T> Entitites)
        {
            _Entity.RemoveRange(Entitites);
        }

        public void Update(T entity)
        {
            _Entity.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _Entity.AsNoTracking().Where(expression);
        }
    }
}
