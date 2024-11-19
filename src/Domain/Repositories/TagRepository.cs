using URFU_Scheduling.Domain.Entities;
using URFU_Scheduling.Infrastructure.Data;

namespace URFU_Scheduling.Domain.Repositories;

public class TagRepository : BaseRepository<Tag>
{
    public TagRepository(SchedulingContext dbContext) : base(dbContext) { }
}

