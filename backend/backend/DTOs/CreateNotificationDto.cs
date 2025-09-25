namespace YamSoft_backend.DTOs
{
    public class CreateNotificationDto
    {
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
