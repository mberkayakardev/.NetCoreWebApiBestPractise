using AkarSoftware.ApiBestPractise.Core.Entities;

namespace AkarSoftware.ApiBestPractise.Core.Repositories
{
    // Hem Costume soruglar hem generic repo işlemleri gelsin
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetProductsWithCategory(int id );
        Task<List<Product>> GetListProductsWithCategories();

    }
}
