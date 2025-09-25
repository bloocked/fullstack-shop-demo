namespace YamSoft_backend.DTOs
{
    /// <summary>
    /// DTO for creating a new product
    /// </summary>
    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public int Stock { get; set; } = 0;
    }
}
