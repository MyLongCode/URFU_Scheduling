using Microsoft.EntityFrameworkCore;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Infrastructure.Data;

namespace URFU_Scheduling_lib.Domain.Repositories;

public class EventRepository : BaseRepository<Event> 
{
    public EventRepository(SchedulingContext dbContext) : base(dbContext){}

    public Event[] GetScheduleEventsByWeek(Guid scheduleId, DateTime dateWeekStart)
    {
        return _dbContext.Set<Event>()
            .Where(x => x.ScheduleId == scheduleId 
                    && dateWeekStart <= x.DateStart 
                    && dateWeekStart.AddDays(7) >= x.DateStart)
            .ToArray();
    }

    //dateMonthStart always 1st day of month
    public Event[] GetScheduleEventsByMonth(Guid scheduleId, DateTime dateMonthStart) 
    {
        return _dbContext.Set<Event>()
            .Where(x => x.ScheduleId == scheduleId
                               && dateMonthStart <= x.DateStart
                               && dateMonthStart.AddMonths(1) >= x.DateStart)
            .ToArray();
    }
}

