using backend.Data;
using backend.Models;
using backend.Repos.Interfaces;

namespace backend.Repos
{
    /// <summary>
    /// Implements the notification repository for data operations
    /// </summary>
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApiDbContext _context;
        public NotificationRepository(ApiDbContext context)
        {
            _context = context;
        }

        public Notification? GetLatestForUser(int userId)
        {
            return _context.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .FirstOrDefault();
        }

        public void Add(Notification notification)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();
        }
    }
}
