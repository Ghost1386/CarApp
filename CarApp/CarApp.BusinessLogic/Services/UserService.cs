using CarApp.BusinessLogic.Interfaces;
using CarApp.Common.Models;
using CarApp.Common.ViewModels;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace CarApp.BusinessLogic.Services;

public class UserService : IUserService
{
    private readonly CarAppContext _carAppContext;
    private readonly IMapper _mapper;

    public UserService(CarAppContext carAppContext, IMapper mapper)
    {
        _carAppContext = carAppContext;
        _mapper = mapper;
    }
    
    public IEnumerable<User> GetUsers()
    {
        return _carAppContext.Users.ToList();
    }

    public IQueryable<User> GetUser(int id)
    {
        return _carAppContext.Users.Where(x => x.Id == id);
    }

    public void Delete(int id)
    {
        _carAppContext.Users.Remove(GetUser(id).FirstOrDefault());
        _carAppContext.SaveChanges();
    }

    public void Create(UserCreateViewModel model)
    {
        if (_carAppContext.Users.Any(x => x.Email == model.Email))
            throw new Exception($"Пользователь {model.Email} уже зарегистрирован.");
        
        var user = _mapper.Map<UserCreateViewModel, User>(model);
        
        user.Name= model.Name;
        user.Email = model.Email;
        user.Password = model.Password;

        _carAppContext.Users.Add(user);
        _carAppContext.SaveChanges();
    }

    public void Edit(UserEditViewModel model)
    {
        var user = _mapper.Map<UserEditViewModel, User>(model);

        user.Name = model.Name;
        user.Email = model.Email;

        _carAppContext.Update(user);
        _carAppContext.SaveChanges();
    }
}