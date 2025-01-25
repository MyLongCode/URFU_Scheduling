using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Interfaces;

namespace URFU_Scheduling.Services.Interfaces
{
    public interface IDailyNotificationService : ICRUDSerivce<DailyNotification>
    {
       public DailyNotification? GetByUser(Guid userId, DateOnly date);
    }
}
