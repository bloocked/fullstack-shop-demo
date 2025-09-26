using backend.Models;

namespace backend.Repos.Interfaces
{
    /// <summary>
    /// Defines the contract for product data operations
    /// </summary>
    public interface IProductRepository
    {
        IEnumerable<Product> GetPaged(int page, int pageSize);
    }
}
