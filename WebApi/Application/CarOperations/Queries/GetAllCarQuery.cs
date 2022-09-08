using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.Application.CarOperationsCommands.Commands;
using WebApi.DbOperations;
using WebApi.Entity;

namespace WebApi.Application.CarOperationsCommands.Queries
{
  public class GetAllCarQuery
  {
    public CarModel Model;
    private readonly ICarDbContext _context;
    private readonly IMapper _mapper;

    public GetAllCarQuery(ICarDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public List<CarModel> Handle()
    {
      var carList = _context.Cars.OrderBy(c => c.Id).ToList();
      var vm = _mapper.Map<List<CarModel>>(carList);

      return vm;
    }
  }
  
}