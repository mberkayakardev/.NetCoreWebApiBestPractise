using AkarSoftware.ApiBestPractise.Core.Entities;

namespace AkarSoftware.ApiBestPractise.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public Task<List<Category>> GetCategoryWithProductsAsync();
        public Task<Category> GetCategoryWithProductsByIdAsync(int id);

    }
}
