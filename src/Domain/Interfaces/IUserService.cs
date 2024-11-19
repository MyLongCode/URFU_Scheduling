namespace URFU_Scheduling.Domain.Interfaces
{
    public interface IUserService
    {
        public bool Register(object? data);

        public bool Authorize(string login, string password);
    }
}
