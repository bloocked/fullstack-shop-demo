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

        /// <summary>
        /// Gets the latest notification for the given user
        /// </summary>
        /// <param name="userId">the user to get notification for</param>
        /// <returns>The notification, or null if not found</returns>
        public Notification? GetLatestForUser(int userId)
        {
            return _context.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .FirstOrDefault();
        }
        /// <summary>
        /// Adds a new notification to the database
        /// </summary>
        /// <param name="notification">The notification to add</param>
        public void Add(Notification notification)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();
        }
    }
}
