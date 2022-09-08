using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entity;

namespace WebApi.Application.ColorOperationsCommands.Commands
{
  public class CreateColorCommand
  {
    public ColorModel Model;
    private readonly ICarDbContext _context;
    private readonly IMapper _mapper;

    public CreateColorCommand(ICarDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public void Handle()
    {
      var color = _context.Colors.SingleOrDefault(c => c.Name == Model.Name);
      if (color is not null)
      {
        throw new InvalidOperationException("Renk Mevcut");
      }
     color = _mapper.Map<Color>(Model);
      _context.Colors.Add(color);
      _context.SaveChanges();
    }
  }

  public class ColorModel
  {
    public string Name { get; set; }
  }
}