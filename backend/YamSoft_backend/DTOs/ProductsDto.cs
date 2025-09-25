namespace YamSoft_backend.DTOs
{
    /// <summary>
    /// Class for transfering product data to frontend
    /// </summary>
    public class ProductsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
