using URFU_Scheduling.Domain.Entities;
using URFU_Scheduling.Infrastructure.Data;

namespace URFU_Scheduling.Domain.Repositories;

public class UserRepository : BaseRepository<User>
{
    public UserRepository(SchedulingContext dbContext) : base(dbContext) { }
}

