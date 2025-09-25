namespace backend.DTOs.Create
{
    /// <summary>
    /// DTO for creating a new user
    /// </summary>
    public class CreateUserDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
