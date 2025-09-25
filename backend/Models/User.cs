namespace backend.Models
{
    /// <summary>
    /// Class for user entity
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // you would hash this
    }
}
