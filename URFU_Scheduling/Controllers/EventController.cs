using Microsoft.AspNetCore.Mvc;

namespace URFU_Scheduling.Controllers
{
    public class EventController : Controller
    {
        // schedule/{scheduleId}/event/
        [HttpPost]
        public async Task<IActionResult> EventCreate(int scheduleId)
        {
            // UserId = authcontext.User 
            // request.body.scheduleEventData
            return Ok();
        }

        // schedule/{scheduleId}/event/{scheduleEventId}/
        [HttpGet]
        public async Task<IActionResult> EventRetrieve(int scheduleId, int scheduleEventId)
        {
            // UserId = authcontext.User
            return Ok("ScheduleEvent obj");
        }

        // schedule/{scheduleId}/event/{scheduleEventId}/
        [HttpPut]
        public async Task<IActionResult> EventUpdate(int scheduleId, int scheduleEventId)
        {
            // UserId = authcontext.User
            // request.body.scheduleEventData
            return Ok();
        }

        // schedule/{scheduleId}/event/{scheduleEventId}/
        [HttpDelete]
        public async Task<IActionResult> EventDelete(int scheduleId, int scheduleEventId)
        {
            // UserId = authcontext.User
            return Ok();
        }

        // schedule/{scheduleId}/event/{scheduleEventId}/addTag/{tagId}/
        [HttpPost]
        public async Task<IActionResult> AddTag(int scheduleId, int scheduleEventId, int tagId) 
        {
            // UserId = authcontext.User
            return Ok();
        }

        // schedule/{scheduleId}/event/{scheduleEventId}/notificate/
        [HttpPost] // или не пост?
        public async Task<IActionResult> NotificateEvent(int scheduleId, int scheduleEventId)
        {
            // UserId = authcontext.User
            return Ok();
        }

        // schedule/{scheduleId}/event/{scheduleEventId}/recurrence/
        [HttpPatch]
        public async Task<IActionResult> EditEventRepeatability(int scheduleId, int scheduleEventId)
        {
            // UserId = authcontext.User
            // request.body.Recurrence
            return Ok();
        }

        // schedule/{scheduleId}/event/{scheduleEventId}/import/?import_type={importType}/
        [HttpPost]
        public async Task<IActionResult> ImportEvent(int scheduleId, int scheduleEventId, string importType)
        {
            // UserId = authcontext.User
            // request.file ?
            return Ok();
        }
    }
}
