using WebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace WebApi.DbOperations
{
  public class CarDbContext : DbContext ,ICarDbContext
  {
    public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
    {}
    public DbSet<Car> Cars { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public override int SaveChanges()
    {
      return base.SaveChanges();
    }
  }
}