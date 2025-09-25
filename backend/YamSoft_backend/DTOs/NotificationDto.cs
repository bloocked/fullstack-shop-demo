namespace YamSoft_backend.DTOs
{
    /// <summary>
    /// Class for transfering notification data to frontend
    /// </summary>
    public class NotificationDto
    {
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
