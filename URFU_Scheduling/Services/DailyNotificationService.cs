using URFU_Scheduling.Services.Interfaces;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Repositories;

namespace URFU_Scheduling.Services
{
    public class DailyNotificationService : CRUDService<DailyNotification>, IDailyNotificationService
    {
        private readonly DailyNotificationRepository _dailyNotificationRepo;

        public DailyNotificationService(DailyNotificationRepository dailyNotificationRepo) : base(dailyNotificationRepo)
        {
            _dailyNotificationRepo = dailyNotificationRepo;
        }

        public DailyNotification GetByUser(Guid userId, DateOnly date)
        {
            return _dailyNotificationRepo.GetByUser(userId, date);
        }
    }
}