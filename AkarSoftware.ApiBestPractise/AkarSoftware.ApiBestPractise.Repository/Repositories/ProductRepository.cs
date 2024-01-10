using AkarSoftware.ApiBestPractise.Core.Entities;
using AkarSoftware.ApiBestPractise.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AkarSoftware.ApiBestPractise.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext) 
        {
            
        }

        public async Task<List<Product>> GetListProductsWithCategories()
        {
            var query = await _appDbContext.Products.Include(x => x.Category).ToListAsync();
            return query;
        }

        public async Task<Product> GetProductsWithCategory(int id)
        {
            var query = await _appDbContext.Products.Include(x=> x.Category).FirstOrDefaultAsync(x=> x.Id == id);
            return query;
                 
        }
    }
}
