using WebApi.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DbOperations
{
  public class DataGenerator
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new CarDbContext(serviceProvider.GetRequiredService<DbContextOptions<CarDbContext>>()))
      {
        if (context.Cars.Any()) return;

        context.Cars.AddRange(
          new Car
          {
           // Id = 1,
            BrandId = 1 ,
            ColorId = 1,
            CarName = "5 20"
          },
          new Car
          {
           // Id = 1,
            BrandId = 2 ,
            ColorId = 2,
            CarName = "Qasqhai"
          },
          new Car
          {
           // Id = 1,
            BrandId = 3 ,
            ColorId = 3,
            CarName = "A6"
          },
          new Car
          {
           // Id = 1,
            BrandId = 4 ,
            ColorId = 4,
            CarName = "Cla 220 D"
          }
        );
        context.Brands.AddRange(
          new Brand
          {
            //Id = 1,
            Name = "BMW"
          },
          new Brand
          {
            //Id = 2,
            Name = "Nissan"
          },
          new Brand
          {
            //Id = 3,
            Name = "Audi"
          },
          new Brand
          {
            //Id = 4,
            Name = "Mercedes"
          }
        );
        context.Colors.AddRange(
          new Color
          {
            //Id = 1,
            Name = "Mavi"
          },
          new Color
          {
            //Id = 2,
            Name = "Beyaz"
          },
          new Color
          {
            //Id = 3,
            Name = "Siyah"
          },
          new Color
          {
            //Id = 4,
            Name = "Gri"
          }
        );
        context.SaveChanges();
      }
    }
  }
}