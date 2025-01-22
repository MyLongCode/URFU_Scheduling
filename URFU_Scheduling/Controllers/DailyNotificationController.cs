using Microsoft.AspNetCore.Mvc;
using URFU_Scheduling.Services.Interfaces;

namespace URFU_Scheduling.Controllers
{
    public class DailyNotificationController : Controller
    {
        private readonly ILogger<DailyNotificationController> _logger;
        private readonly IDailyNotificationService _dailyNotificationService;

        public DailyNotificationController(
            ILogger<DailyNotificationController> logger,
            IDailyNotificationService dailyNotificationService)
        {
            _logger = logger;
            _dailyNotificationService = dailyNotificationService;
        }


        [HttpGet("/daily-notifications/user/{userId}/{nowDate}")]
        public IActionResult GetDailyNotificationByUser(Guid userId, string nowDate)
        {
            if (!DateOnly.TryParse(nowDate, out DateOnly date))
            {
                return BadRequest("Invalid date format. Use YYYY-MM-DD.");
            }
            var notififaction = _dailyNotificationService.GetByUser(userId, date);
            if (notififaction != null) return Ok(notififaction);
            return NoContent();
        }
    }
}
