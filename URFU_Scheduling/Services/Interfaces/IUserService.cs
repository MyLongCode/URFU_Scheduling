using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Interfaces;

namespace URFU_Scheduling.Services.Interfaces
{
    public interface IUserService
    {
        public bool Register(object? data);

        public bool Authorize(string login, string password);
    }
}
