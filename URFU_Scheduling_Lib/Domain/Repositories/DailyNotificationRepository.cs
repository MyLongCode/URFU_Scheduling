using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Dynamic;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Infrastructure.Data;

namespace URFU_Scheduling_lib.Domain.Repositories
{
    public class DailyNotificationRepository : BaseRepository<DailyNotification>
    {
        public DailyNotificationRepository(SchedulingContext dbContext) : base(dbContext) { }

        public DailyNotification? GetByUser (Guid userId, DateOnly date)  =>
            _dbContext.Set<DailyNotification>()
            .Where(x => x.UserId.Equals(userId) && x.SentAt.Date.Equals(date))
            .SingleOrDefault();
    }
}
