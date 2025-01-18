using Microsoft.Extensions.Hosting;
using Quartz;
using System.Threading;
using System.Threading.Tasks;

namespace URFU_Scheduling.Jobs
{
    public class QuartzHostedService : IHostedService
    {
        private readonly IScheduler _scheduler;
        private readonly ILogger<QuartzHostedService> _logger;


        public QuartzHostedService(IScheduler scheduler, ILogger<QuartzHostedService> logger)
        {
            _scheduler = scheduler;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
          _logger.LogInformation("QuartzHostedService starting.");
            try
            {
                  var job = JobBuilder.Create<DailyEventNotificationJob>()
                      .WithIdentity("DailyEventNotificationJob", "NotificationGroup")
                       .Build();

                     var trigger = TriggerBuilder.Create()
                       .WithIdentity("DailyEventNotificationTrigger", "NotificationGroup")
                        .WithCronSchedule("0/30 * * * * ?") // Запуск каждую секунду
                       .Build();

                    await _scheduler.ScheduleJob(job, trigger, cancellationToken);
                     _logger.LogInformation("Job Scheduled.");
                    await _scheduler.Start(cancellationToken);
                     _logger.LogInformation("Scheduler started.");

            }
            catch (Exception ex)
            {
               _logger.LogError(ex, "Error starting scheduler.");
            }

        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("QuartzHostedService stopping.");
            if(_scheduler == null)
            {
                _logger.LogInformation("Scheduler is null.");
                return;
            }
            if (_scheduler.IsStarted)
            {
                 await _scheduler.Shutdown(cancellationToken);
                 _logger.LogInformation("Scheduler shutdown.");
            }
             else
            {
                 _logger.LogInformation("Scheduler is not started.");
            }
        }
    }
}
