using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Interfaces;

namespace URFU_Scheduling.Services.Interfaces
{
    public interface IUserService
    {
        public bool Register(IRegistrationData data);

        public Task<bool> Authorize(string login, string password);
        public Guid GetIdByLogin(string login);
    }
}
