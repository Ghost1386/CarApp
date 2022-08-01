using CarApp.Common.Models;

namespace CarApp.BusinessLogic.Interfaces;

public interface ICarService
{
    IEnumerable<Car> Get();

    void AddAll();
}