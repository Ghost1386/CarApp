using CarApp.BusinessLogic.Interfaces;
using CarApp.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public IActionResult GetAllUser()
    {
        return Ok(_userService.GetUsers());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        return Ok(_userService.GetUser(id));
    }
    
    [HttpPost]
    public IActionResult CreateUser(UserCreateViewModel model)
    {
        _userService.Create(model);
        return Ok();
    }
    
    [HttpDelete]
    public IActionResult DeleteUser(int id)
    {
        _userService.Delete(id);
        return Ok();
    }
    
    [HttpPut]
    public IActionResult EditUser(UserEditViewModel model)
    {
        _userService.Edit(model);
        return Ok();
    }
}