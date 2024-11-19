using URFU_Scheduling.Domain.Entities;
using URFU_Scheduling.Infrastructure.Data;

namespace URFU_Scheduling.Domain.Repositories;

public class ScheduleRepository : BaseRepository<Schedule>
{
    public ScheduleRepository(SchedulingContext dbContext) : base(dbContext) { }
}

