using YamSoft_backend.DTOs;

namespace YamSoft_backend.Services
{
    /// <summary>
    /// Defines business logic related to product operations
    /// </summary>
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProducts(int page, int pageSize);
    }
}
