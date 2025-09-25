namespace backend.DTOs
{
    /// <summary>
    /// Class for transferring user data to frontend
    /// </summary>
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
    }
}
