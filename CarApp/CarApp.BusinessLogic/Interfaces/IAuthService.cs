using CarApp.Common.Models;

namespace CarApp.BusinessLogic.Interfaces;

public interface IAuthService
{
    string Post(User user);

    User GetUser(string email, string password);
}