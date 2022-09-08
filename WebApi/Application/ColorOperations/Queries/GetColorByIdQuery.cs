using System;
using System.Linq;
using AutoMapper;
using WebApi.Application.ColorOperationsCommands.Commands;
using WebApi.DbOperations;

namespace WebApi.Application.ColorOperationsCommands.Queries
{
  public class GetColorByIdQuery
  {
    public int ColorId;
    private readonly ICarDbContext _context;
    private readonly IMapper _mapper;

    public GetColorByIdQuery(ICarDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public ColorModel Handle()
    {
      var color = _context.Colors.SingleOrDefault(c => c.Id == ColorId);
      if (color is null)
      {
        throw new InvalidOperationException("Renk numarası bulunamadı");
      }
      var vm = _mapper.Map<ColorModel>(color);
      return vm;
    }
  }
}