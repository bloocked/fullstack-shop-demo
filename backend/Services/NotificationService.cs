using backend.DTOs;
using backend.Models;
using backend.Repos.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repo;

        public NotificationService(INotificationRepository repo)
        {
            _repo = repo;
        }

        public NotificationDto SendNotification(int userId, string message)
        {
            var notification = new Notification
            {
                UserId = userId,
                Message = message,
                CreatedAt = DateTime.UtcNow
            };

            _repo.Add(notification);
            Console.WriteLine($"THE ID OF NOTI IS ====== {notification.Id}");

            // Map to DTO before returning
            var notificationDto = new NotificationDto
            {
                Id = notification.Id,
                Message = notification.Message,
                CreatedAt = notification.CreatedAt
            };

            return notificationDto;
        }

        public NotificationDto? GetLatestForUser(int userId)
        {
            var notif = _repo.GetLatestForUser(userId);
            if (notif == null) return null;
            return new NotificationDto
            {
                Id = notif.Id,
                Message = notif.Message,
                CreatedAt = notif.CreatedAt
            };
        }
    }
}
