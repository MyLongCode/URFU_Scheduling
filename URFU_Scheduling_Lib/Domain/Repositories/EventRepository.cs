using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Infrastructure.Data;

namespace URFU_Scheduling_lib.Domain.Repositories;

public class EventRepository : BaseRepository<Event>
{
    public EventRepository(SchedulingContext dbContext) : base(dbContext) { }
}

