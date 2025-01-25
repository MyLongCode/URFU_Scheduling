﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using URFU_Scheduling.Services;
using URFU_Scheduling_lib.Controllers;
using URFU_Scheduling_lib.Domain.Interfaces;
using URFU_Scheduling_lib.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using URFU_Scheduling.Models.ViewModels;
using URFU_Scheduling.Services.Interfaces;

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

        public IActionResult Denied()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(_userService.Register(model)) return RedirectToAction("Index", "Profile");
                else ViewBag.Message = "Ошибка во время регистарции";
            }
            else
            {
                ViewBag.Message = "Введите корректные логин или пароль";
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
                    return RedirectToAction("Index", "Profile");
                }
                else
                {
                    ViewBag.Message = "Неверный логин или пароль";
                }
            }
            return View(model);
        } 
    }
}