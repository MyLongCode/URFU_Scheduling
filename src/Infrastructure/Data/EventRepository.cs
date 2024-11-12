namespace URFU_Scheduling.Infrastructure.Data;

public class EventRepository : BaseRepository
{
    public EventRepository(SchedulingContext dbContext) : base(dbContext){ }
}

