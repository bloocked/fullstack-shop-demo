using backend.DTOs;

namespace backend.Services.Interfaces
{
    /// <summary>
    /// Defines business logic related to product operations
    /// </summary>
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProducts(int page, int pageSize);
    }
}
