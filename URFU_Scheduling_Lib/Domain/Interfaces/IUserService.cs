namespace URFU_Scheduling_lib.Domain.Interfaces
{
    public interface IUserService
    {
        public bool Register(IRegistrationData data);

        public Task<bool> Authorize(string login, string password);
    }
}
