using CarApp.Common.Models;
using CarApp.Common.ViewModels;

namespace CarApp.BusinessLogic.Interfaces;

public interface IUserService
{
    IEnumerable<User> GetUsers();
        
    IQueryable<User> GetUser(int id);

    void Delete(int id);

    void Create(UserCreateViewModel model);

    void Edit(UserEditViewModel model);
}