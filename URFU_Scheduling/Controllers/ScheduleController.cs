using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace URFU_Scheduling.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }  
    }
}
