using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using URFU_Scheduling.Models;
using URFU_Scheduling.Services;
using URFU_Scheduling_lib.Controllers;
using URFU_Scheduling_lib.Domain.Interfaces;
using URFU_Scheduling_lib.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace URFU_Scheduling.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly UserRepository _userRepo;

        public AuthController(ILogger<HomeController> logger, IUserService userService,  UserRepository userRepository)
        {
            _logger = logger;
            _userRepo = userRepository;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Denied()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(_userService.Register(model)) ViewBag.Message = "Registration successful";
                else ViewBag.Message = "Registration failed";
            }
            else
            {
                ViewBag.Message = "Invalid login or password";
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_userService.Authorize(model.Login, model.Password).Result)
                {
                    
                    return RedirectToAction("Home", "Schedule");
                }
                else
                {
                    ViewBag.Message = "Invalid login or password";
                }
            }
            return View(model);
        } 
    }
}