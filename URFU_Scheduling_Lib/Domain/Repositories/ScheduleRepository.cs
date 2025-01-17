using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Infrastructure.Data;

namespace URFU_Scheduling_lib.Domain.Repositories;

public class ScheduleRepository : BaseRepository<Schedule>
{
    public ScheduleRepository(SchedulingContext dbContext) : base(dbContext) { }

    public List<Schedule> GetAllUserSchedules(Guid userId) => _dbContext.Schedules.Where(s =>  s.UserId == userId).ToList();
}

