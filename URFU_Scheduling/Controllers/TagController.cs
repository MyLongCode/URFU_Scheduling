using Microsoft.AspNetCore.Mvc;
using URFU_Scheduling.Controllers.DTO;
using URFU_Scheduling.Services;
using URFU_Scheduling_lib.Controllers;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Repositories;
using URFU_Scheduling_lib.Infrastructure.Data;
using URFU_Scheduling.Services.Interfaces;
using System.Drawing;
using System.Text.RegularExpressions;
using URFU_Scheduling.Models.ViewModels;

namespace URFU_Scheduling.Controllers
{
    public class TagController : Controller
    {
        private readonly ILogger<TagController> _logger;
        private readonly IUserService _userService;
        private readonly ITagService _tagService;

        public TagController(
            ILogger<TagController> logger,
            SchedulingContext db,
            ITagService tagService,
            IUserService userService)
        {
            _logger = logger;
            _tagService = tagService;
            _userService = userService;
        }

        [HttpGet("/tag")]
        public async Task<IActionResult> TagCreate()
        {
            var viewmodel = new CreateTagViewModel()
            {
                UserId = _userService.GetIdByLogin(User.Identity.Name)
            };
            return View(viewmodel);
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

        private Color StringToColor(string color)
        {
            var nums = Regex.Matches(color, @"\d+")
                .Select(x => Int32.Parse(x.Value))
                .ToArray();

            return Color.FromArgb(nums[0], nums[1], nums[2]);
        }
    }
}