using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Data;
using System.Security.Claims;
using URFU_Scheduling_lib.Domain.Interfaces;
using URFU_Scheduling_lib.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using URFU_Scheduling.Utilities;
using URFU_Scheduling.Models.ViewModels;

namespace URFU_Scheduling.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public UserService(
            UserRepository userRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _userRepo = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Authorize(string login, string password)
        {
            var user = _userRepo.GetAll().FirstOrDefault(u => u.Login == login);
            if(user == null) return false;
            var isPasswordCorrect = PasswordHasher.VerifyPassword(password, user.Password);
            if(!isPasswordCorrect) return false;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Login),
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
            return true;
        }

        public bool Register(IRegistrationData model) 
        {
            _userRepo.Add(new URFU_Scheduling_lib.Domain.Entities.User()
            {
                Login = model.Login,
                Password = PasswordHasher.HashPassword(model.Password)
            });
            return true;
        }
    }
}
