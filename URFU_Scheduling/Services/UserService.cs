using URFU_Scheduling_lib.Domain.Interfaces;
using URFU_Scheduling_lib.Domain.Repositories;

namespace URFU_Scheduling.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepo;
        private readonly IHttpContextAccessor _httpContext;

        public UserService(
            UserRepository userRepository,
            IHttpContextAccessor httpContext)
        {
            _userRepo = userRepository;
            _httpContext = httpContext;
        }

        public bool Authorize(string login, string password)
        {
            throw new NotImplementedException();
        }

        public bool Register(object? data)
        {
            throw new NotImplementedException();
        }
    }
}
