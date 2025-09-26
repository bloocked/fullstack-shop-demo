using backend.Models;
using backend.Repos.Interfaces;

namespace backend.Repos
{
    /// <summary>
    /// Implements the product repository for data operations
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly Data.ApiDbContext _context;

        public ProductRepository(Data.ApiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetPaged(int page, int pageSize)
        {
            return _context.Products
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
