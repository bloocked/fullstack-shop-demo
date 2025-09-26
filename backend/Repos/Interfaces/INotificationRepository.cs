using backend.Models;

namespace backend.Repos.Interfaces
{
    /// <summary>
    /// Defines the contract for notification data operations
    /// </summary>
    public interface INotificationRepository
    {
        Notification? GetLatestForUser(int userId);
        
        void Add(Notification notification);
    }
}
