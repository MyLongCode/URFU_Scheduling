using URFU_Scheduling_lib.Domain.Entities;

namespace URFU_Scheduling_lib.Domain.Interfaces
{
    public interface INotificationProvider
    {
        public void Send(string message, User user);
    }
}
