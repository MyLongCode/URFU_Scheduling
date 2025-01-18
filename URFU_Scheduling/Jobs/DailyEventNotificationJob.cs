using Microsoft.CodeAnalysis.Operations;
using Quartz;
using URFU_Scheduling_lib.Domain.Repositories;
using URFU_Scheduling.Services.Interfaces;
using URFU_Scheduling_lib.Domain.Entities;

namespace URFU_Scheduling.Jobs
{
    public class DailyEventNotificationJob : IJob
    {
        private readonly IEventService _eventService;
        private readonly IUserService _userService;
        private readonly IScheduleService _scheduleService;
        private readonly ILogger<DailyEventNotificationJob> _logger;

        public DailyEventNotificationJob(
                IEventService eventService,
                IUserService userService,
                IScheduleService scheduleService,
                ILogger<DailyEventNotificationJob> logger
                )
        {
            _eventService = eventService;
            _userService = userService;
            _scheduleService = scheduleService;
            _logger = logger;
        }


        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("DailyEventNotificationJob started");
            var today = DateTime.Today;
            var schedules = _scheduleService.GetAll()
                .Where(schedule => schedule.Events.Any(ev => ev.DateStart.Date.Equals(today.Date)));
            Send(schedules, today);
            _logger.LogInformation("DailyEventNotificationJob finished");
        }

        public void Send(IEnumerable<Schedule> schedules, DateTime today)
        {
            if (!schedules.Any())
            {
                _logger.LogInformation("No schedules found.");

            }
            else
            {
                _logger.LogInformation($"Found {schedules.Count()} schedules for today");
                foreach (Schedule schedule in schedules)
                {
                    var user = _userService.Get(schedule.UserId);
                    var events = schedule.Events.Where(ev => ev.DateStart.Date.Equals(today));
                    _logger.LogInformation($"{schedule.Name}{user.Login}");
                    foreach (Event todayEvent in events)
                    {
                        _logger.LogInformation($"{todayEvent.Name} at {todayEvent.DateStart} to {todayEvent.DateStart + todayEvent.Duration}");
                    }
                }
            }
        }
    }
}
