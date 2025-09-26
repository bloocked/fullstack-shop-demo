using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Gets a paginated list of products
        /// </summary>
        /// <param name="page">the page of products to fetch</param>
        /// <param name="pageSize">the product amount to fetch per page</param>
        /// <returns>An <see cref="IActionResult"/> containing the list of products, NotFound otherwise</returns>
        // GET: api/products
        [HttpGet]
        public IActionResult GetProducts([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var products = _productService.GetProducts(page, pageSize);
            if (products == null || !products.Any())
            {
                return NotFound(new { error = "No products found." });
            }

            return Ok(products);
        }
    }
}
