using Microsoft.AspNetCore.Mvc;

namespace URFU_Scheduling.Controllers
{
    public class ScheduleController : Controller
    {
        // schedule/ 
        [HttpPost]
        public async Task<IActionResult> ScheduleCreate()
        {
            // UserId = authcontext.User
            // response.body.Schedule
            return Ok();
        }

        // schedule/{scheduleId}/
        [HttpGet]
        public async Task<IActionResult> ScheduleRetrieve(int scheduleId)
        {
            // UserId = authcontext.User
            return Ok("Schedule obj");
        }

        // schedule/{scheduleId}/
        [HttpPut]
        public async Task<IActionResult> ScheduleUpdate(int scheduleId)
        {
            // UserId = authcontext.User
            // response.body.Schedule
            return Ok();
        }

        // schedule/{scheduleId}/
        [HttpDelete]
        public async Task<IActionResult> ScheduleDelete(int scheduleId)
        {
            // UserId = authcontext.User
            return Ok();
        }

        // schedule/{scheduleId}/add-event/
        [HttpPost]
        public async Task<IActionResult> AddEvent(int scheduleId)
        {
            // UserId = authcontext.User
            // response.body.scheduleEvent
            return Ok();
        }

        // schedule/{scheduleId}/events/?period={period}
        [HttpGet]
        public async Task<IActionResult> GetEvents(int scheduleId, string period)
        {
            // period query
            // UserId = authcontext.User
            return Ok("week or month schedule obj");
        }

        // schedule/{scheduleId}/export/
        [HttpGet]
        public async Task<IActionResult> ScheduleExport(int scheduleId)
        {
            // UserId = authcontext.User
            return Ok("schedule file");
        }

        // schedule/import/?import_type={importType}/
        [HttpPost]
        public async Task<IActionResult> ScheduleImport(string importType)
        {
            // UserId = authcontext.User
            // request.file ?
            return Ok();
        }
    }
}
