using YamSoft_backend.Data;
using YamSoft_backend.DTOs;
using YamSoft_backend.Repos;

namespace YamSoft_backend.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<ProductDto> GetProducts(int page, int pageSize)
        {
            return _repo.GetPaged(page, pageSize)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Stock = p.Stock
                })
                .ToList();
        }
    }
}
