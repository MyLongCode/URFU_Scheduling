using Quartz;
using URFU_Scheduling.Services.Interfaces;
using URFU_Scheduling_lib.Domain.Entities;

namespace URFU_Scheduling.Jobs
{
    public class DailyEventNotificationJob : IJob
    {
        private readonly IScheduleService _scheduleService;
        private readonly ILogger<DailyEventNotificationJob> _logger;
        private readonly IDailyNotificationService _dailyNotificationService;

        public DailyEventNotificationJob(
                IDailyNotificationService dailyNotificationService,
                IScheduleService scheduleService,
                ILogger<DailyEventNotificationJob> logger
                )
        {
            _dailyNotificationService = dailyNotificationService;
            _scheduleService = scheduleService;
            _logger = logger;
        }


        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("DailyEventNotificationJob started");
            var today = DateTime.Today;

            var usersWithEvents = _scheduleService.GetAll()
                .Where(schedule => schedule.Events.Any(ev => ev.DateStart.Date.Equals(today.Date)))
                .GroupBy(x => x.UserId);

            foreach (var userGroup in usersWithEvents)
            {
                var userId = userGroup.Key;
                var totalEvents = userGroup.SelectMany(schedule => schedule.Events).Where(ev => ev.DateStart.Date.Equals(today.Date)).Count();
                var scheduleCount = userGroup.Count();

                var message = $"У вас сегодня {totalEvents} событий в {scheduleCount} расписаниях.";

                var newNotification = new DailyNotification
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    SentAt = today,
                    Message = message
                };

                _dailyNotificationService.Create(newNotification);

                _logger.LogInformation($"Notification for user {userId}: {message}");
            }

            _logger.LogInformation("DailyEventNotificationJob finished");
        }
    }
}
