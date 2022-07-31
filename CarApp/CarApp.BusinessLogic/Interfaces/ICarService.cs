using CarApp.Common.Models;

namespace CarApp.BusinessLogic.Interfaces;

public interface ICarService
{
    IEnumerable<Car> GetCars();

    void AddAllCars();
}