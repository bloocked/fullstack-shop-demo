using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    /// <summary>
    /// Class for product entity
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Precision(18,2)]
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
