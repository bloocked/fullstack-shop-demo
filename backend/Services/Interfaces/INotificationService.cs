using backend.DTOs;

namespace backend.Services.Interfaces
{
    /// <summary>
    /// Defines a contract related to notification operations
    /// </summary>
    public interface INotificationService
    {
        void SendNotification(int userId, string message);
        NotificationDto? GetLatestForUser(int userId);
    }
}
