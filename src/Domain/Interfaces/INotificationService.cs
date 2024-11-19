using URFU_Scheduling.Domain.Entities;

namespace URFU_Scheduling.Domain.Interfaces
{
    public interface INotificationService
    {
        public void SendNotification(INotificationProvider provider, string message, User user);
    }
}
