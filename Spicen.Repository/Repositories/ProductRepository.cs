using Microsoft.EntityFrameworkCore;
using Spicen.Core;
using Spicen.Core.Repositories;

namespace Spicen.Repository.Repositories
{
    /// <summary>
    /// Add on top of generic repository
    /// </summary>
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
