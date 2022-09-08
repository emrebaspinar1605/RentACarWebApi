using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.Application.ColorOperationsCommands.Commands;
using WebApi.DbOperations;

namespace WebApi.Application.ColorOperationsCommands.Queries
{
  public class GetAllColorQuery
  {
    public ColorModel _model;
    private readonly ICarDbContext _context;
    private readonly IMapper _mapper; 

    public GetAllColorQuery(ICarDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public List<ColorModel> Handle()
    {
      var colorList = _context.Colors.OrderBy(c => c.Id).ToList();
      var vm = _mapper.Map<List<ColorModel>>(colorList);
      return vm;
    }
    
  }
}