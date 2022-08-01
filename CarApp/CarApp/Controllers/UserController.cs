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
    public IActionResult Get()
    {
        return Ok(_userService.Get());
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_userService.Get(id));
    }
    
    [HttpPost]
    public IActionResult Post(UserCreateViewModel model)
    {
        _userService.Create(model);
        return Ok();
    }
    
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        _userService.Delete(id);
        return Ok();
    }
    
    [HttpPut]
    public IActionResult Put(UserEditViewModel model)
    {
        _userService.Edit(model);
        return Ok();
    }
}