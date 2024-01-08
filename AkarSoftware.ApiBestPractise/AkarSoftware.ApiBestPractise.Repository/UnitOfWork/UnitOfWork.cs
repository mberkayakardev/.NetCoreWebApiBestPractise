using AkarSoftware.ApiBestPractise.Core.UnitOfWorks;

namespace AkarSoftware.ApiBestPractise.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Commit()
        {
            _appDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            _appDbContext.SaveChanges();
        }
    }
}
