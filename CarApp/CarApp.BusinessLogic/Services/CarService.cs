using CarApp.BusinessLogic.Interfaces;
using CarApp.Common.Models;

namespace CarApp.BusinessLogic.Services;

public class CarService : ICarService
{
    private readonly CarAppContext _carAppContext;
    private readonly Parser.Parser _parser;

    public CarService(CarAppContext carAppContext, Parser.Parser parser)
    {
        _carAppContext = carAppContext;
        _parser = parser;
    }
    
    public IEnumerable<Car> Get()
    {
        return _carAppContext.Cars.ToList();
    }

    public void AddAll()
    {
        var CarList = _parser.GetInfo();

        foreach (var cars in CarList)
        {
            Car car = new Car();
            car.Info = cars;
            
            _carAppContext.Cars.Add(car);
            _carAppContext.SaveChanges();
        }
    }
}