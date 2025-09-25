using YamSoft_backend.Models;

namespace YamSoft_backend.Repos
{
    /// <summary>
    /// Defines the contract for product data operations
    /// </summary>
    public interface IProductRepository
    {
        Product? GetById(int id);
        Product? GetByName(string name);
        void Add(Product product);
        void Delete(Product product);
    }
}
