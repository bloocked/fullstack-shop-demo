using backend.Data;
using backend.DTOs;
using backend.Repos.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services
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
                    Stock = p.Stock,
                    ImageUrl = string.IsNullOrEmpty(p.ImageUrl)
                    ? "https://picsum.photos/200/300"
                    : p.ImageUrl
                })
                .ToList();
        }
    }
}
