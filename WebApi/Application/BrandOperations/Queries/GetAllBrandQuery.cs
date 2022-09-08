using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.Application.BrandOperationsCommands.Commands;
using WebApi.DbOperations;

namespace WebApi.Application.BrandOperationsCommands.Queries
{
  public class GetAllBrandQuery
  {
    private readonly ICarDbContext _context;
    private readonly IMapper _mapper;

    public GetAllBrandQuery(ICarDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public List<BrandModel> Handle()
    {
      var brandList = _context.Brands.OrderBy(b => b.Id).ToList();
      var vm = _mapper.Map<List<BrandModel>>(brandList);
      return vm;
    }
  }
}