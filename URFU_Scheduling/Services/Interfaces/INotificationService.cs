using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Interfaces;

namespace URFU_Scheduling.Services.Interfaces
{
    public interface INotificationService
    {
        public void SendNotification(INotificationProvider provider, string message, User user);
    }
}
