using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.CarOperationsCommands.Commands
{
  public class DeleteCarCommand
  {
    public int CarId;
    private readonly ICarDbContext _context;

    public DeleteCarCommand(ICarDbContext context)
    {
      _context = context;
    }
    public void Handle()
    {
      var car = _context.Cars.SingleOrDefault(c => c.Id == CarId);
      if(car is null)
      {
        throw new InvalidOperationException("Araç bulunamadı");
      }
      _context.Cars.Remove(car);
      _context.SaveChanges();
    }
  }
}