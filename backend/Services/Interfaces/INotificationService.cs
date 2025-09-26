using backend.DTOs;

namespace backend.Services.Interfaces
{
    /// <summary>
    /// Defines a contract related to notification operations
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Sends a notification to the specified user.
        /// </summary>
        /// <param name="userId">Target user identifier.</param>
        /// <param name="message">Notification message text.</param>
        /// <returns>
        /// The created <see cref="NotificationDto"/> if the notification was created successfully;
        /// otherwise <c>null</c> (for example, when the user is not found or send failed).
        /// </returns>
        NotificationDto? SendNotification(int userId, string message);

        /// <summary>
        /// Gets the most recent notification for the specified user.
        /// </summary>
        /// <param name="userId">Target user identifier.</param>
        /// <returns>The latest <see cref="NotificationDto"/> for the user, or <c>null</c> if none.</returns>
        NotificationDto? GetLatestForUser(int userId);
    }
}
