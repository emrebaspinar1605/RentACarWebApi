using WebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace WebApi.DbOperations
{
  public interface ICarDbContext
  {
    DbSet<Car> Cars {get; set;}
    DbSet<Brand> Brands {get; set;}
    DbSet<Color> Colors {get; set;}
    DbSet<Customer> Customers {get; set;}
    int SaveChanges();
  }
}