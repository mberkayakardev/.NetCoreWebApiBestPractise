using AkarSoftware.ApiBestPractise.Core.Repositories;
using AkarSoftware.ApiBestPractise.Core.Services;
using AkarSoftware.ApiBestPractise.Core.UnitOfWorks;
using System.Linq.Expressions;

namespace AkarSoftware.ApiBestPractise.Services.Services
{
    public class Service<T> : IService<T> where T : class
    {
        // Business kodlarımızı yazacağız.  Repository ile haberleşecek ve veritabanı işlemleri yapılacaktır.
        // Repo katmanında Savechanges methodu hiç kullanılmadı. 
        // Savechanges çağırabilmek için UnitOFWork implemente ettik 
        // Repository içerisinde SaveChanges i çağırmadık.
        // SAvechanges i merkezi bir yere aldık ki benim kontrolümde olsun 
        // farklı repolar ile çağırırken tüm değişiklikleri bir transaction şeklinde db ye yansıtsın ve hata varsa tüm işlemleri otomatik olarak RollBack yapması için bu şekilde yürütülmektedir. 

        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync(); // Bu komut çalıştığında Entity e aslında id değeri atanır. 
            // Bir adet Genel DTO oluşturursun list dto gibi düşün Create DTO alırsın CreateDto yu normal nesneye cast ettikten sonra onu create edeceksin
            // ya repository normalde sana Entity döner o entity i de git List e göre maple sonrasında yine son kullanıcıya id li bir şekilde yine dTO dön
            // entity dönme  ama bu seferlik biz buraya bu işlemi bu şekilde gerçekleştirdik .
            return entity;
            // Entity parametre olarak geldiğinde id yok savechanges çalışınca id değerini entity nin id sine atar. Dönüşte Entity dönmen gerekecektir. 
            // 
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> Entities)
        {
            await _repository.AddRangeAsync(Entities);
            await _unitOfWork.CommitAsync();
            return Entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task Delete(T entity)
        {
            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveRange(IEnumerable<T> Entitites)
        {
            _repository.RemoveRange(Entitites);
            await _unitOfWork.CommitAsync();
        }

        public async Task Update(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();

        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
