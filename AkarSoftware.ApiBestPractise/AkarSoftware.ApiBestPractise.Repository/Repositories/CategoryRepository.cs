using AkarSoftware.ApiBestPractise.Core.Entities;
using AkarSoftware.ApiBestPractise.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AkarSoftware.ApiBestPractise.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<Category>> GetCategoryWithProductsAsync()
        {
            var result = await _appDbContext.Categories.Include(x=> x.Products).ToListAsync();
            return result;
        }

        public async Task<Category> GetCategoryWithProductsByIdAsync(int id)
        {

            var result = await _appDbContext.Categories.Include(x => x.Products).FirstOrDefaultAsync(x=> x.Id == id);
            return result;
        }
    }
}
