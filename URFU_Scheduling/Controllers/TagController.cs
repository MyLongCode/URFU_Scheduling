using Microsoft.AspNetCore.Mvc;

namespace URFU_Scheduling.Controllers
{
    public class TagController : Controller
    {
        // tag/ 
        [HttpPost]
        public async Task<IActionResult> TagCreate()
        {
            // UserId = authcontext.User
            // response.body.Name
            // response.body.Color
            return Ok();
        }

        // tag/{tagId}/
        [HttpGet]
        public async Task<IActionResult> TagRetrieve(int tagId)
        {
            // UserId = authcontext.User
            return Ok("tag obj");
        }

        // tag/{tagId}/
        [HttpPut]
        public async Task<IActionResult> TagUpdate(int tagId)
        {
            // UserId = authcontext.User
            // response.body.Name
            // response.body.Color
            return Ok();
        }

        // tag/{tagId}/
        [HttpDelete]
        public async Task<IActionResult> TagDelete(int tagId)
        {
            // UserId = authcontext.User
            return Ok();
        }

        // tag/
        [HttpGet]
        public async Task<IActionResult> TagList()
        {
            // UserId = authcontext.User
            return Ok("all tag obj");
        }
    }
}
