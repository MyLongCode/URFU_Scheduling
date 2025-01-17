using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Infrastructure.Data;

namespace URFU_Scheduling_lib.Domain.Repositories
{
    
    public class RecurrenceRepository : BaseRepository<Recurrence>
    {
        public RecurrenceRepository(SchedulingContext dbContext) : base(dbContext) { }
    }
}
