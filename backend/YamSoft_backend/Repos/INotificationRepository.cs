using YamSoft_backend.Models;

namespace YamSoft_backend.Repos
{
    /// <summary>
    /// Defines the contract for notification data operations
    /// </summary>
    public interface INotificationRepository
    {
        Notification? GetById(int id);
        void Add(Notification notification);
        void Delete(Notification notification);
    }
}
