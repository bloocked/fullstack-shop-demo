namespace YamSoft_backend.DTOs
{
    /// <summary>
    /// Class for transfering notification data to frontend
    /// </summary>
    public class NotificationsDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
