using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.CarOperationsCommands.Commands
{
  public class UpdateCarCommand
  {
    public CarModel Model;
    public int CarId;
    private readonly ICarDbContext _context;

    public UpdateCarCommand(ICarDbContext context)
    {
      _context = context;
    }
    public void Handle()
    {
      var car = _context.Cars.SingleOrDefault(c => c.Id == CarId);
      if (car is null)
      {
        throw new InvalidOperationException("Araç bulunamadı");
      }
      if (_context.Cars.Any(c => c.CarName == Model.CarName))
      {
        throw new InvalidOperationException("Araç zaten mevcut");
      }
      car.CarName = string.IsNullOrEmpty(Model.CarName.Trim())? car.CarName : Model.CarName;
      car.BrandId = Model.BrandId != default ? Model.BrandId : car.BrandId;
      car.ColorId = Model.ColorId != default ? Model.ColorId : car.ColorId;
      _context.SaveChanges();
    }
  }
}