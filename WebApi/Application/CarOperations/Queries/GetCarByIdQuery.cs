using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.CarOperationsCommands.Commands;
using WebApi.DbOperations;
using WebApi.Entity;

namespace WebApi.Application.CarOperationsCommands.Queries
{
  public class GetCarByIdQuery
  {
    public int CarId;
    public CarViewModel Model;
    private readonly ICarDbContext _context;
    private readonly IMapper _mapper;

    public GetCarByIdQuery(ICarDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public CarModel Handle()
    {
      var car = _context.Cars.Include(c => c.Color).Include(b => b.Brand).SingleOrDefault(c => c.Id == CarId);
      if (car is null)
      {
        throw new InvalidOperationException("Araç bulunamadı");
      }
      var vm = _mapper.Map<CarModel>(car);
      return vm;
    }
  }
  public class CarViewModel
  {
    public string CarName { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
  }
}