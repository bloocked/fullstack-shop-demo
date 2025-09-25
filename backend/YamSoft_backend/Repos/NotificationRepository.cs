using YamSoft_backend.Data;
using YamSoft_backend.Models;

namespace YamSoft_backend.Repos
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
        /// Gets the notification with given id
        /// </summary>
        /// <param name="id">the id to query for</param>
        /// <returns>The notification, or null if not found</returns>
        public Notification? GetById(int id)
        {
            return _context.Notifications.Find(id);
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

        /// <summary>
        /// Deletes notification from the database
        /// </summary>
        /// <param name="notification">The notification to delete</param>
        public void Delete(Notification notification)
        {
            _context.Notifications.Remove(notification);
            _context.SaveChanges();
        }
    }
}
