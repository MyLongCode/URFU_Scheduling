namespace URFU_Scheduling.Infrastructure.Data;

public class UserRepository : BaseRepository
{
    public UserRepository(SchedulingContext dbContext) : base(dbContext) { }
}

