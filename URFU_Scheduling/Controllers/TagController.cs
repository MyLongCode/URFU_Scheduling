using Microsoft.AspNetCore.Mvc;
using URFU_Scheduling.Controllers.DTO;
using URFU_Scheduling.Services;
using URFU_Scheduling_lib.Controllers;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Repositories;
using URFU_Scheduling_lib.Infrastructure.Data;
using URFU_Scheduling.Services.Interfaces;

namespace URFU_Scheduling.Controllers
{
    public class TagController : Controller
    {
        private readonly ILogger<TagController> _logger;

        private readonly ITagService _tagService;

        public TagController(
            ILogger<TagController> logger,
            SchedulingContext db,
            TagService tagService)
        {
            _logger = logger;
            _tagService = tagService;
        }

        [HttpPost("/tag")]
        public async Task<IActionResult> TagCreate(TagDTO dto)
        {
            return Ok(_tagService.Create(new Tag()
            {
                UserId = dto.UserId,
                Name = dto.Name,
                Color = dto.Color
            }));
        }

        [HttpGet("/tag/{tagId}")]
        public async Task<IActionResult> TagRetrieve(Guid tagId)
        {
            var tag = _tagService.Get(tagId);
            if (tag == null) return NotFound("no tag");
            return Ok(tag);
        }

        [HttpPut("/tag/{tagId}")]
        public async Task<IActionResult> TagUpdate(Guid tagId, TagDTO dto)
        {
            var tag = _tagService.Get(tagId);
            if (tag == null) return NotFound("no tag");

            //tag.UserId = dto.UserId;
            tag.Name = dto.Name;
            tag.Color = dto.Color;
            _tagService.Update(tag);

            return Ok();
        }

        [HttpDelete("/tag/{tagId}")]
        public async Task<IActionResult> TagDelete(Guid tagId)
        {
            var tag = _tagService.Get(tagId);
            if (tag == null) return NotFound("no tag");

            _tagService.Delete(tag);
            return Ok();
        }

        // все тэги пользователя? если так, то примерно такой метод:
        [HttpGet("/tag")]
        public async Task<IActionResult> TagList(Guid userId)
        {
            // var tags = _tagService.GetUserTags(userId);
            return Ok();
        }
    }
}