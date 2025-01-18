using Microsoft.AspNetCore.Mvc;
using URFU_Scheduling.Controllers.DTO;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling.Services.Interfaces;

namespace URFU_Scheduling.Controllers
{
    public class RecurrenceController : Controller
    {
        private readonly ILogger<RecurrenceController> _logger;

        private readonly IRecurrenceService _recurrenceService;

        public RecurrenceController(
            ILogger<RecurrenceController> logger, 
            IRecurrenceService recurrenceService)
        {
            _logger = logger;
            _recurrenceService = recurrenceService;
        }

        [HttpPost("/recurrence")]
        public async Task<IActionResult> RecurrenceCreate([FromBody] RecurrenceDTO dto)
        {
            return Ok(_recurrenceService.Create(new Recurrence()
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Value = dto.Value
            }));
        }

        [HttpGet("/recurrence/{recurrnceId}")]
        public async Task<IActionResult> RecurrenceRetrieve(Guid recurrnceId)
        {
            var recurrence = _recurrenceService.Get(recurrnceId);
            if (recurrence == null) return NotFound("no recurrence");
            return Ok(recurrence);
        }

        [HttpPut("/recurrence/{recurrenceId}")]
        public async Task<IActionResult> RecurrenceUpdate(Guid recurrenceId, RecurrenceDTO dto)
        {
            var recurrence = _recurrenceService.Get(recurrenceId);
            if (recurrence == null) return NotFound("no recurrence");

            //tag.UserId = dto.UserId;
            recurrence.Name = dto.Name;
            recurrence.Value = dto.Value;
            _recurrenceService.Update(recurrence);

            return Ok();
        }

        [HttpDelete("/recurrence/{recurrenceId}")]
        public async Task<IActionResult> RecurrenceDelete(Guid recurrenceId)
        {
            var recurrence = _recurrenceService.Get(recurrenceId);
            if (recurrence == null) return NotFound("no recurrence");

            _recurrenceService.Delete(recurrence);
            return Ok();
        }

    }
}
