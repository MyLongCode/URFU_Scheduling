using Microsoft.AspNetCore.Mvc;
using URFU_Scheduling.Services;
using URFU_Scheduling_lib.Controllers;
using URFU_Scheduling_lib.Domain.Repositories;
using URFU_Scheduling_lib.Infrastructure.Data;

namespace URFU_Scheduling.Controllers
{
    public class TagController : Controller
    {
        private readonly ILogger<TagController> _logger;

        private readonly TagService _tagService;

        public TagController(
            ILogger<TagController> logger,
            SchedulingContext db,
            TagService tagService)
        {
            _logger = logger;
            _tagService = tagService;
        }
        [HttpPost("/tag")]
        public async Task<IActionResult> TagCreate()
        {
            return Ok();
        }

        [HttpGet("/tag/{tagId}")]
        public async Task<IActionResult> TagRetrieve(Guid tagId)
        {
            return Ok("tag obj");
        }

        [HttpPut("/tag/{tagId}")]
        public async Task<IActionResult> TagUpdate(Guid tagId)
        {
            return Ok();
        }

        [HttpDelete("/tag/{tagId}")]
        public async Task<IActionResult> TagDelete(Guid tagId)
        {
            return Ok();
        }

        [HttpGet("/tag")]
        public async Task<IActionResult> TagList()
        {
            return Ok("all tag obj");
        }
    }
}
