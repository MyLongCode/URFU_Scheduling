using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Infrastructure.Data;

namespace URFU_Scheduling_lib.Domain.Repositories;

public class UserRepository : BaseRepository<User>
{
    public UserRepository(SchedulingContext dbContext) : base(dbContext) { }
}

