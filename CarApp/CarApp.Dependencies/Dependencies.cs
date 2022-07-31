using CarApp.BusinessLogic.Interfaces;
using CarApp.BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CarApp.Dependencies;

public class Dependencies
{
    public static void AddIService(IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
    }
}