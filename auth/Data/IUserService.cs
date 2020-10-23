using Auth01.Models;

namespace Auth01.Data
{
    public interface IUserService
    {
        bool Register(string user, string password, string role, string email);
        User Login(string user, string password);
        User GetUserByMail(string email);
    }
}