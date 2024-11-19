using URFU_Scheduling_lib.Domain.Entities;

namespace URFU_Scheduling_lib.Domain.Interfaces
{
    public interface INotificationService
    {
        public void SendNotification(INotificationProvider provider, string message, User user);
    }
}
