using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Infrastructure.Data;

namespace URFU_Scheduling_lib.Domain.Repositories;

public class TagRepository : BaseRepository<Tag>
{
    public TagRepository(SchedulingContext dbContext) : base(dbContext) { }

    public List<Tag> GetUserTags(Guid userId) => _dbContext.Tags.Where(t => t.UserId == userId).ToList();
}

