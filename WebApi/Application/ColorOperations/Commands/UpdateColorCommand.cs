using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.ColorOperationsCommands.Commands
{
  public class UpdateColorCommand
  {
    public ColorModel Model;
    public int ColorId;
    private readonly ICarDbContext _context;

    public UpdateColorCommand(ICarDbContext context)
    {
      _context = context;
    }
    public void Handle()
    {
      var color = _context.Colors.SingleOrDefault(c => c.Id == ColorId);
      if (color is null)
      {
        throw new InvalidOperationException("Renk numarası Bulunamadı");
      }
      if (_context.Colors.Any(c => c.Name.ToLower() == Model.Name.ToLower()))
      {
        throw new InvalidOperationException("Renk zaten mevcut");
      }
      color.Name = string.IsNullOrEmpty(Model.Name.Trim())? color.Name : Model.Name;
    }
  }
}