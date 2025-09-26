namespace backend.DTOs.Create
{
    /// <summary>
    /// DTO for creating a new notification
    /// </summary>
    public class CreateNotificationDto
    {
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
