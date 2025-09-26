using backend.DTOs;

namespace backend.Services.Interfaces
{
    /// <summary>
    /// Defines business logic related to product operations
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets a paged list of products
        /// </summary>
        /// <param name="page">The product page to fetch from</param>
        /// <param name="pageSize">The amount of products to fetch per page</param>
        /// <returns>An <see cref="IEnumerable{ProductDto}"/> list of
        /// <see cref="ProductDto"/> containing product data</returns>
        IEnumerable<ProductDto> GetProducts(int page, int pageSize);
    }
}
