using URFU_Scheduling.Domain.Entities;
using URFU_Scheduling.Infrastructure.Data;

namespace URFU_Scheduling.Domain.Repositories;

public class EventRepository : BaseRepository<Event>
{
    public EventRepository(SchedulingContext dbContext) : base(dbContext) { }
}

