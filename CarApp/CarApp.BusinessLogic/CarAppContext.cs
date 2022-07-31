using CarApp.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace CarApp.BusinessLogic;

public class CarAppContext : DbContext
{
    public CarAppContext(DbContextOptions<CarAppContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }
    
    public DbSet<User> Users { get; set; }
}