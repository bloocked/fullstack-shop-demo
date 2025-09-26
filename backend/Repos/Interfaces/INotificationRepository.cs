using backend.Models;

namespace backend.Repos.Interfaces
{
    /// <summary>
    /// Defines the contract for notification data operations
    /// </summary>
    public interface INotificationRepository
    {
        /// <summary>
        /// Gets the latest notification for the given user
        /// </summary>
        /// <param name="userId">the user to get notification for</param>
        /// <returns>The notification, or null if not found</returns>
        Notification? GetLatestForUser(int userId);

        /// <summary>
        /// Adds a new notification to the database
        /// </summary>
        /// <param name="notification">The notification to add</param>
        void Add(Notification notification);
    }
}
