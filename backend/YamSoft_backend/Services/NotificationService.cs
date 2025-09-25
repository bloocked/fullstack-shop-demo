using YamSoft_backend.DTOs;
using YamSoft_backend.Models;
using YamSoft_backend.Repos;

namespace YamSoft_backend.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repo;

        public NotificationService(INotificationRepository repo)
        {
            _repo = repo;
        }

        public void SendNotification(int userId, string message)
        {
            var notification = new Notification
            {
                UserId = userId,
                Message = message,
                CreatedAt = DateTime.UtcNow
            };

            _repo.Add(notification);
        }

        public NotificationDto? GetLatestForUser(int userId)
        {
            var notif = _repo.GetLatestForUser(userId);
            if (notif == null) return null;
            return new NotificationDto
            {
                Message = notif.Message,
                CreatedAt = notif.CreatedAt
            };
        }
    }
}
