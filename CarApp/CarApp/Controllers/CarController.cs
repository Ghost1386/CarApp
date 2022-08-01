using CarApp.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;
    
    public CarController(ICarService carService)
    {
        _carService = carService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_carService.Get());
    }
    
    [HttpPost]
    public IActionResult Post()
    {
        _carService.AddAll();
        return Ok();
    }
}