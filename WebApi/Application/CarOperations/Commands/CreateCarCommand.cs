using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entity;

namespace WebApi.Application.CarOperationsCommands.Commands
{
  public class CreateCarCommand
  {
    public CarModel Model;
    private readonly ICarDbContext _context;
    private readonly IMapper _mapper;

    public CreateCarCommand(ICarDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public void Handle()
    {
      var car = _context.Cars.SingleOrDefault(c => c.CarName.ToLower() == Model.CarName.ToLower());
      if (car is null)
      {
        throw new InvalidOperationException("Araba mevcut");
      }
      car = _mapper.Map<Car>(Model);
      _context.Cars.Add(car);
      _context.SaveChanges();
    }
  }

  public class CarModel
  {
    public string CarName { get; set; }
    public int BrandId { get; set; }
    public int ColorId { get; set; }
  }
}