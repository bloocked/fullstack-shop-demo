using backend.Models;

namespace backend.Repos.Interfaces
{
    /// <summary>
    /// Defines the contract for product data operations
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Gets a paged list of products
        /// </summary>
        /// <param name="page">Page number (1-based).</param>
        /// <param name="pageSize">How many products per page.</param>
        /// <returns>Paged list of products.</returns>
        IEnumerable<Product> GetPaged(int page, int pageSize);
    }
}
