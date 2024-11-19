using URFU_Scheduling.Domain.Entities;

namespace URFU_Scheduling.Domain.Interfaces
{
    public interface INotificationProvider
    {
        public void Send(string message, User user);
    }
}
