using YamSoft_backend.Models;

namespace YamSoft_backend.Repos
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

        /// <summary>
        /// Gets the product with given id
        /// </summary>
        /// <param name="id">the id to query for</param>
        /// <returns>The product, or null if not found</returns>
        public Product? GetById(int id)
        {
            return _context.Products.Find(id);
        }

        /// <summary>
        /// Gets first product with given name
        /// </summary>
        /// <param name="id">the name to query for</param>
        /// <returns>The product, or null if not found</returns>
        public Product? GetByName(string name)
        {
            return _context.Products.FirstOrDefault(p => p.Name == name);
        }

        /// <summary>
        /// Adds a new product to the database
        /// </summary>
        /// <param name="product">The product to add</param>
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes product from the database
        /// </summary>
        /// <param name="product">The product to delete</param>
        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
