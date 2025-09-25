using YamSoft_backend.DTOs;

namespace YamSoft_backend.Services
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
